var FieldDropDownColumn = 0;
var Forms = [];
var FieldBoxDataSourcelength;
var FirstkendoDropDownTree;
var varGropByArray = new Array();
var dataSource;
$(document).ready(function () {
    try {
       
        //-------Initialize kendo list Box in the div---------
        var i = 0;
        $('.searchResult').each(function (e) {           
            var pageid = $(this).attr('id').split("_")[1];
            $('.example_'+i).each(function (e) {
               var formid= $(this).attr('id').split("_")[2];
                //j++; k++;
                $("#fieldValues_" + pageid + "_" + formid).kendoListBox({
                    dataTextField: "Name",
                    dataValueField: "Id",
                    dataSource: {
                       type: "GET",
                        transport: {
                            read:
                            {
                                dataType: "json",
                                //async:true,
                                url: abp.appPath + "App/MyCustom/GetFieldsByFormAndPageId",
                                data:
                                {
                                    formId: formid,
                                    pageId: pageid
                                }  
                                  
                            }
                        },
                            schema: {

                            data: function (response) {
                               
                                var obj = response.result.data;
                               // console.log(JSON.parse(obj));
                                return JSON.parse(obj);
                            },

                         

                        },
                    },
                    connectWith: "selectedFields_" + pageid + "_" + formid,
                    
                    toolbar: {
                        tools: ["transferTo","transferFrom","transferAllTo","transferAllFrom"],  

                    },
                    add: OnDeselect,
                });

                $("#selectedFields_" + pageid + "_" + formid).kendoListBox({
                    dataTextField: "Name",
                    dataValueField: "Id",
                    add: OnAdd,  
                });

                //----------kendo multiselect---------
                $("#" +pageid + "_" + formid).kendoMultiSelect({
                    dataTextField: "fieldName",
                    dataValueField: "Id",
                    dataSource: [],
                    filter: "contains",
                    placeholder: "Select",
                    deselect: OnRemove,
                    open: Onopen
                });   

            });
            i++;
        });
        
       
    }
    catch (e) {
        alert(e.message);
    }
   
    $("#btnNext").click(function () {
      
        $('#SelectFieldsArea').hide('slow');
        $('#QueryBuilderArea').show('slow');
     

    });
    $("#btnPrevious").click(function () {
        $('#QueryBuilderArea').hide('slow');
        $('#SelectFieldsArea').show('slow');
    });
    

    FirstkendoDropDownTree=$("#Column_0").kendoDropDownTree({
        dataTextField: "text",
        dataValueField: "id",     
        placeholder: "Select item.....",
        //dataSource:[],
        select: dropdownOnChange,
        //clearButton: function (e) { console.log(e);}
        change: function (e)
        {
           // debugger;
            var currentValue = $("#Column_0").data("kendoDropDownTree").value();
            var value = this.value();
            if (value == "")
            {
                var text = this.text();
            }
            //alert(value);
            console.log($(this));
        }
       
    }).data("kendoDropDownTree");

   
    $(".Operator").kendoDropDownList({
        dataTextField: "text",
        dataValueField: "value",
        placeholder: "Select item.....", 
        dataSource: [
           // { text: "Select", value: "0" },
            { text: "Equal To", value: "=" },
            { text: "Not Equal To", value: "!=" },
            { text: "Less Then", value: "<" },
            { text: "Less Then Equal To", value: "<=" },
            { text: "Greater Then", value: ">" },
            { text: "Greater Then Equal To", value: ">=" }
        ]
    }).data("kendoDropDownList");

    //----------------------------Group By Dropdown-------------------
    $("#GroupBy").kendoDropDownTree({
        dataTextField: "text",
        dataValueField: "value",
        optionLabel: "Select"
    });  
});
 //---------------CheckBox change event--------------
function ChecBoxFunction(obj) {    
    var myid = $(obj).attr('id').split('_');
   var test = $(obj).parent().parent().parent().parent().closest('Div');
    //var pageId = test.parent().find('#pageId')[0];// get page Id
    var pageId = myid[3];// get page Id
    var pageName = $(test.parent().find('#pageId')[0]).attr("data-pagename");
    var formValues = $(obj).parent().parent().parent().find('#formdata')[0];// get form Name
    //var formId = $(formValues).attr('data-id');
    var formId = myid[4];
    // checkbox checked event
    if ($(obj).is(":checked")) {
        // get parent of the checkbox and find the select inputs in the div
        var FieldBox = $("#fieldValues_" + pageId + "_" + formId).data("kendoListBox");       
        var SelectBox = $("#selectedFields_" + pageId+ "_" + formId).data("kendoListBox");
         //var FieldBox = $("#fieldValues_" + myid[3]).data("kendoListBox");
        //var SelectBox = $("#selectedFields_" + myid[3]).data("kendoListBox");
            var oldDataSource = SelectBox.dataSource.data();
        var newDataSource = FieldBox.dataSource.data();
        //get json data for selected value 
        DataSelectFunctionality(newDataSource, pageId, formId, formValues, pageName);
            //merge the datasource of two list box
            $.merge(newDataSource, oldDataSource);
        SelectBox.dataSource.data(newDataSource);// insert the merged data
       // console.log(SelectBox.dataSource.data());
      
        //clear out old data
        FieldBox.setDataSource([]); 

       
    }
    // checkbox uncheck event
    else {
        // get parent of the checkbox and find the select inputs in the div
        var FieldBox1 = $("#fieldValues_" + pageId+ "_" + formId).data("kendoListBox");
        var SelectBox1 = $("#selectedFields_" + pageId+ "_" + formId).data("kendoListBox");
        //var FieldBox1 = $("#fieldValues_" + myid[3]).data("kendoListBox");
        //var SelectBox1 = $("#selectedFields_" + myid[3]).data("kendoListBox");
            var newDataSource1 = SelectBox1.dataSource.data();
            var oldDataSource1 = FieldBox1.dataSource.data();
            //merge the datasource of two list box
        $.merge(newDataSource1, oldDataSource1);
        // insert the merged data   
        FieldBox1.dataSource.data(newDataSource1); 
         //remove data from json for unselected value 
        DataDeselectFunctionality(FieldBox1.dataSource.data(), pageId, formId);
        //clear out old data
        SelectBox1.setDataSource([]); 
       
    }
}


function OnAdd(e)
{
   
    var dataItem = e.dataItems;       
    var obj = e.sender.element[0];  
    var test1 = $(obj).parent().parent().parent().parent().parent().closest('Div'); 
    // get page Id
    var pageId = test1.parent().find('#pageId')[0];
    var pageName=$(pageId).attr("data-pagename");
    // get form Value
    var formValues = test1.find('#formdata')[0];    
    // get Form Id
    var formId=$(formValues).attr('data-id');  
    DataSelectFunctionality(dataItem, pageId.value, formId, formValues, pageName);

    var FieldBox1 = $("#fieldValues_" + pageId.value + "_" + formId).data("kendoListBox"); 
    if (FieldBox1.dataSource.data().length == dataItem.length) {
        var CheckBox = test1.find('input[type=checkbox]');
        var CheckBoxId = CheckBox[0].id;
        $('#' + CheckBoxId).prop('checked', true);   
    }

                               
    


}

function OnDeselect(e)
{   
    var dataItem = e.dataItems;
    var obj = e.sender.element[0];
    var test1 = $(obj).parent().parent().parent().parent().parent().closest('Div');
    //get Form Value
    var formValues = test1.find('#formdata')[0];
    //get page id   
    var pageId = test1.parent().find('#pageId')[0];
    //get Form id 
    var formId = $(formValues).attr('data-id');

    //--------------Do not remove this commented Code 
    var CheckBox = test1.find('input[type=checkbox]');
    var CheckBoxId = CheckBox[0].id;     
    $('#'+CheckBoxId).prop('checked', false);    
    DataDeselectFunctionality(dataItem, pageId.value, formId);   
}

function MyFields(id, name, type, pageId, formId) {
  this.Id = id;
    this.fieldName = name;
    this.fieldType = type;
    //---------
    this.pageId = pageId;
    this.formId = formId;
    
}

function MyForm(pageId,id, name,Fields) {
    this.pageId = pageId;
    this.formId = id;
    this.formName = name;
    this.MyFields = Fields;

}

function CustomClass(pageId, pageName, form)
{
    this.id = pageId;
    this.text = pageName;
    this.items = form;
    
}
function CustomFormClass(formId, formName, fields)
{
    this.id = formId;
    this.text = formName;
    this.items = fields;

}
function CustomFields(id, name,type,pageId,formId) {
    this.id = id;
    this.text = name;
    this.type = type;

    //added afterwards
    this.pageId = pageId;
    this.formId = formId;

}

var test = [];

function DataSelectFunctionality(dataItem, pageId, formId, formValues, pageName) {      
    
    var Fields = []; 
    for (var i = 0; i < dataItem.length; i++) {
        var FieldsData = new MyFields(dataItem[i].Id, dataItem[i].Name, dataItem[i].Type, pageId, formId);
        Fields.push(FieldsData);
    }   
    var fromLength = Forms.length;
    var formStatus = false;
    for (var i = 0; i < fromLength; i++) {

        if (Forms[i].formId == formId && Forms[i].pageId == pageId) {
            //Form already present in array
            formStatus = true;
        }
    }
    var multiselectId = pageId + "_" + formId;
    var SelectMultiSelectBox = $("#" + multiselectId).data("kendoMultiSelect");
    var selectedValues = SelectMultiSelectBox.value();
    var SelectMultidata = SelectMultiSelectBox.dataSource.data();
  
    
    //-------------------------------------------------------
    if (formStatus) {    
      
        // Insert fields at the form Myfields Object
        for (var j = 0; j < Fields.length; j++) {
            var position = Forms.findIndex(x => x.formId == formId && x.pageId == pageId);
            Forms[position].MyFields.push(Fields[j]);
            // insert new element into copy of multiselect data
            SelectMultidata.push({ fieldName: Fields[j].fieldName, Id: Fields[j].Id, fieldType: Fields[j].fieldType});           
            selectedValues.push(Fields[j].Id);
           
        }
        
    }
    else {
        var FormData = new MyForm(pageId, formId, formValues.innerText, Fields);
        Forms.push(FormData);     
        $("#div_" + multiselectId).show();
      
        // Insert fields at the form Myfields Object
        for (var j = 0; j < Fields.length; j++) {
            
            // insert new element into copy of multiselect data
            SelectMultidata.push({ fieldName: Fields[j].fieldName, Id: Fields[j].Id, fieldType: Fields[j].fieldType});
            selectedValues.push(Fields[j].Id);
           
           
        }
   
       
      
    }
    //---------- insert the  data in multiselect datasource----------------   
    SelectMultiSelectBox.dataSource.data(SelectMultidata);
    SelectMultiSelectBox.value(selectedValues);// Show selected fields in kendo multi select
    //----------------------------------------------------------
    InsertDataInDropDownTree(formStatus, pageId, pageName, formId, formValues, Fields)
    var myJsonString = JSON.stringify(Forms);
    //console.log();
  
}

function DataDeselectFunctionality(dataItem, pageId, formId)
{
   
    var Fields = [];
    for (var i = 0; i < dataItem.length; i++) {

        var FieldsData = new MyFields(dataItem[i].Id, dataItem[i].Name, dataItem[i].Type, pageId, formId);
        Fields.push(FieldsData);
    }
    for (var i = 0; i < Forms.length; i++) {
        if (Forms[i].formId == formId && Forms[i].pageId == pageId) {
            //Form already present in array
            var position = Forms.findIndex(x => (x.formId == formId && x.pageId == pageId));
            for (var j = 0; j < Fields.length; j++) {
                var positionoffields = Forms[position].MyFields.findIndex(x => x.Id == Fields[j].Id);
                Forms[position].MyFields.splice(positionoffields, 1);
              //Reomve Vlaue from kendo multiselect on toggle of kendo list box
                var multiselectId = pageId +"_"+ formId;
                var SelectMultiSelectBox = $("#" + multiselectId).data("kendoMultiSelect");
                var SelectMultidata = SelectMultiSelectBox.dataSource.data();
                for (k = SelectMultidata.length - 1; k >= 0; k--) {                    
                    if (SelectMultidata[k].Id == Fields[j].Id) {
                        SelectMultiSelectBox.dataSource.remove(SelectMultidata[k]);
                    }

                }     
               
               
                ReomveDataInDropDownTree(pageId, formId, Fields[j]);
               


                ////When all fields are removed from select box then remove the form too from the array
                if (Forms[position].MyFields.length == 0) {
                    Forms.splice(position, 1);
                             
                    //Remove kendo multi select on removing the form
                    $("#div_" + pageId + "_" + formId).hide();
                   
                }                
            }

        }
    }
    var myJsonString = JSON.stringify(Forms);
  
}

/////---------Remove value from Kendo multiselect(X button functionality) -------------
function OnRemove(e) {    
   
    var dataItem = e.dataItem;
    var obj = e.sender.element[0];
    var test1 = obj.id.split("_");      
    //get page id   
    var pageId = test1[0];
    //get Form id 
    var formId = test1[1];
    // logic to add and remove field from teh kendo list box
    var FieldBox1 = $("#fieldValues_" + pageId+ "_" + formId).data("kendoListBox");
    var SelectBox1 = $("#selectedFields_" + pageId + "_" + formId).data("kendoListBox");
    var newDataSource1 = SelectBox1.dataSource.data();
    var fieldBoxDataSource = FieldBox1.dataSource;
    var dataSource = new kendo.data.DataSource();
    for (k = newDataSource1.length - 1; k >= 0; k--) {
        if (newDataSource1[k].Id == dataItem.Id) {
            var datatoBeRemoved = newDataSource1[k];// value to be added or removed
            // remove the value from Selected list box 
            SelectBox1.dataSource.remove(newDataSource1[k]);           
            // add a new data item in the field box            
            fieldBoxDataSource.add(datatoBeRemoved);
            // save the created data item
            fieldBoxDataSource.sync();
            dataSource.add(datatoBeRemoved);
        }
    } 
    
   

    RemoveData(dataSource.data(), pageId, formId);   
    $('#Select_All_Fields_' + pageId + "_" + formId).prop('checked', false);
   

}

/////---------Restrict Kendo multiselect open function-------------
function Onopen(e) {  
    e.preventDefault();
}

function RemoveData(dataItem, pageId, formId) {
   // debugger;
    var Fields = [];
    for (var i = 0; i < dataItem.length; i++) {

        var FieldsData = new MyFields(dataItem[i].Id, dataItem[i].Name, dataItem[i].Type);
        Fields.push(FieldsData);
    }
    for (var i = 0; i < Forms.length; i++) {
        if (Forms[i].formId == formId && Forms[i].pageId == pageId) {
            //Form already present in array
            var position = Forms.findIndex(x => (x.formId == formId && x.pageId == pageId));
            for (var j = 0; j < Fields.length; j++) {
                var positionoffields = Forms[position].MyFields.findIndex(x => x.Id == Fields[j].Id);
                Forms[position].MyFields.splice(positionoffields, 1);

                //---------------------------------------------------
        
                ReomveDataInDropDownTree(pageId, formId, Fields[j]);
                //var fieldsdropDown = $("#Column_0").data("kendoDropDownTree");
                //var SelectFieldDropDowndata = fieldsdropDown.treeview.dataSource.data();

                //for (k = SelectFieldDropDowndata.length - 1; k >= 0; k--) {
                //    if (SelectFieldDropDowndata[k].id == pageId) {
                //        for (var y = 0; y < SelectFieldDropDowndata[k].items.length; y++) {
                //            if (SelectFieldDropDowndata[k].items[y].id == formId) {
                //                var fieldsListPresent = SelectFieldDropDowndata[k].items[y].items;
                //                for (var m = 0; m < fieldsListPresent.length; m++) {
                //                    if (fieldsListPresent[m].id == Fields[j].Id) {

                //                        var field = fieldsListPresent[m];

                //                        fieldsdropDown.treeview.dataSource.remove(field);

                //                    }
                //                }                               
                //            }
                //            if (SelectFieldDropDowndata[k].items[y].items.length == 0) {
                //                fieldsdropDown.treeview.dataSource.remove(SelectFieldDropDowndata[k].items[y]);
                //                //SelectFieldDropDowndata.remove(SelectFieldDropDowndata[k].items[y]);
                //            }
                //        }                        
                //        if (SelectFieldDropDowndata[k].items.length == 0) {
                //            fieldsdropDown.treeview.dataSource.remove(SelectFieldDropDowndata[k]);
                //           // SelectFieldDropDowndata.remove(SelectFieldDropDowndata[k]);
                //        }
                //    }

                //}     

                //------------------------------------------------------
                
                ////When all fields are removed from select box then remove the form too from the array
                if (Forms[position].MyFields.length == 0) {                   
                    Forms.splice(position, 1);
                    // hide the kendo multiselect when the form is removed            
                    $("#div_" + pageId + "_" + formId).hide();    
                }
            }

        }
    }
    var myJsonString = JSON.stringify(Forms);
    
}


function dropdownOnChange(e) {
    debugger;
    if (e.sender.dataItem(e.node).hasChildren) {
        e.preventDefault();
    } else
    {
        var selectedData = e.sender.dataItem(e.node);
   
        //----------------Reset Controls---------------- 
        var varPassValue = e.sender.dropdowntree.element.attr('id');
        var ColumnNo = varPassValue.split("_");

        var varCondition = "Condition_" + ColumnNo[1];
        var varValue = "Value_" + ColumnNo[1];
        $('#' + varCondition).data("kendoDropDownList");
                          
        $('#' + varValue).val('');

        ////--------------Add selected Item into  Group by dropdown----------------
        if ($.inArray(selectedData.text, varGropByArray) == -1) {  //--------------check duplicate
            varGropByArray.push(selectedData.text);
           // var data = [];
          
            $("#GroupBy").getKendoDropDownTree().dataSource.insert({  //--------------- Add item
                "text": selectedData.text,
                "value": selectedData.id
                //"pageId": selectedData.pageId,
                //  "formId": selectedData.formId
            });
        }
     

       
        
        
    }
    


}

function addRow() {   
   
    FieldDropDownColumn = FieldDropDownColumn + 1;
   
    var idNumber = FieldDropDownColumn;
    var varColumn = "Column_" + idNumber;
    var varCondition = "Condition_" + idNumber;
    var varAnd = "And_" + idNumber;

    $("#tblQueryControl").append("<tr><td><div class='row RowController'><div class='col-12' align='center'> <select id='And_" + idNumber + "' class='LogicalOperator' ></select> </div> <div class='col-3 SelectedFieldsDropDown'><select id='Column_" + idNumber + "'  class='dropdownlist' ></select> </div><div class='col-3'><input id='Condition_" + idNumber + "' class='Operator'></div><div class='col-3'><input id='Value_" + idNumber + "' type='text' name='Operator' /></div><div class='col - 3'> <button type='button' onclick='return removeRow(this)' title='Cancel'><span class='k-icon k-i-delete'></span></button></div></div></tr></td>");

    //-------------Intialize Column----------
   
    var fieldDropDown = $("#Column_0").data("kendoDropDownTree");
    fielddropdownDataSource = fieldDropDown.dataSource.data();
    var data = [];
    for (var a = 0; a < fielddropdownDataSource.length; a++)
    {
        var Forms = [];
        for (var b = 0; b < fielddropdownDataSource[a].items.length; b++)
        {
            var Fields = [];
            for (var c = 0; c < fielddropdownDataSource[a].items[b].items.length; c++) {
               // var FieldsData = new CustomFields(fielddropdownDataSource[a].items[b].items[c].id, fielddropdownDataSource[a].items[b].items[c].text, fielddropdownDataSource[a].items[b].items[c].type);
                var FieldsData = new CustomFields(fielddropdownDataSource[a].items[b].items[c].id, fielddropdownDataSource[a].items[b].items[c].text, fielddropdownDataSource[a].items[b].items[c].type, fielddropdownDataSource[a].id, fielddropdownDataSource[a].items[b].id);
                Fields.push(FieldsData);
            }
           
            var FormData = new CustomFormClass(fielddropdownDataSource[a].items[b].id, fielddropdownDataSource[a].items[b].text, Fields);
            Forms.push(FormData);     

        }
    
        var FormData = new CustomClass(fielddropdownDataSource[a].id, fielddropdownDataSource[a].text, Forms);
        data.push(FormData);
    }

    $("#" + varColumn).kendoDropDownTree({
        dataTextField: "text",
        dataValueField: "id",
        dataSource: data,
        placeholder: "Select item.....",        
      select: dropdownOnChange
    }).data("kendoDropDownTree");
    //console.log(data);
   
   
   
    //-------------Intialize Condition----------
    $("#" + varCondition).kendoDropDownList({
        dataTextField: "text",
        dataValueField: "value",
        placeholder: "Select item.....", 
        dataSource: [            
            { text: "Equal To", value: "=" },
            { text: "Not Equal To", value: "!=" },
            { text: "Less Then", value: "<" },
            { text: "Less Then Equal To", value: "<=" },
            { text: "Greater Then", value: ">" },
            { text: "Greater Then Equal To", value: ">=" }
        ]
    });


    //-------------Intialize dropdown----------
    $("#" + varAnd).kendoDropDownList({
        dataTextField: "text",
        dataValueField: "value",
        placeholder: "Select item.....", 
        dataSource: [
            //{ text: "Select", value: "0" },
            { text: "And", value: "&&" },
            { text: "Or", value: "||" },
            { text: "Not", value: "!=" },
        ]
    });

}

function removeRow(input) {
    input.parentNode.parentNode.parentNode.remove();
}

function GenerateQuery() {
 
   
    var queryString = '';
    $("#tblQueryControl tr td").each(function (i, row) {

        var varColumnID = "#Column_" + i;
        var varCondition = "#Condition_" + i;
        var varValue = "#Value_" + i;
        var varAnd = "#And_" + i;
        if (i == 0) {
            var condition = $(varColumnID).data('kendoDropDownTree').text();
            var operator = $(varCondition).data('kendoDropDownList').value();
            var value = $(varValue).val();
            queryString += condition + ' ' + operator + ' ' + value + ' ';
           
        } else {
            var condition = $(varColumnID).data('kendoDropDownTree').text();
            var operator = $(varCondition).data('kendoDropDownList').value();
            var value = $(varValue).val();
            var And = $(varAnd).data('kendoDropDownList').text();
            queryString += condition + ' ' + operator + ' ' + value + ' ' + And + ' ';
            
        }
    });
    alert(queryString);
}

function InsertDataInDropDownTree(formStatus, pageId, pageName, formId, formValues, Fields)
{
  
    var rowCount = $('#tblQueryControl tr').length;   
    for (var i = 0; i < rowCount; i++)
    {
        var globaldatasource = [];
        var fieldsdropDown = $("#Column_" + [i]).data("kendoDropDownTree");       
        var SelectFieldDropDowndata = fieldsdropDown.treeview.dataSource.data();
        if (formStatus) {
            var Items = [];
            // Insert fields at the form Myfields Object
            for (var j = 0; j < Fields.length; j++) {
                //Items.push({ id: Fields[j].Id, text: Fields[j].fieldName, type: Fields[j].fieldType});
                Items.push({ id: Fields[j].Id, text: Fields[j].fieldName, type: Fields[j].fieldType, pageId: pageId, formId: formId});


                globaldatasource.push({ id: formId, text: formValues.innerText, items: Items });
                for (var x = 0; x < SelectFieldDropDowndata.length; x++) {
                    if (SelectFieldDropDowndata[x].id == pageId) {
                        for (var y = 0; y < SelectFieldDropDowndata[x].items.length; y++) {
                            if (SelectFieldDropDowndata[x].items[y].id == formId) {
                                //SelectFieldDropDowndata[x].items[y].items.push({ id: Fields[j].Id, text: Fields[j].fieldName, type: Fields[j].fieldType});
                               SelectFieldDropDowndata[x].items[y].items.push({ id: Fields[j].Id, text: Fields[j].fieldName, type: Fields[j].fieldType, pageId: pageId, formId: formId });
                            }
                        }

                    }

                }
            }

        }
        else {

            var Items = [];
            // Insert fields at the form Myfields Object
            for (var j = 0; j < Fields.length; j++) {
               // Items.push({ id: Fields[j].Id, text: Fields[j].fieldName, type: Fields[j].fieldType });
                Items.push({ id: Fields[j].Id, text: Fields[j].fieldName, type: Fields[j].fieldType, pageId: pageId, formId: formId});

            }

            globaldatasource.push({ id: formId, text: formValues.innerText, items: Items });
            if (SelectFieldDropDowndata.length == 0) {
                SelectFieldDropDowndata.push({ id: pageId, text: pageName, items: globaldatasource });
            }
            else {
                var positionOfPage;
                var PageStatus = false;
                for (var x = 0; x < SelectFieldDropDowndata.length; x++) {
                    if (SelectFieldDropDowndata[x].id == pageId) {
                        PageStatus = true;
                        positionOfPage = x;
                    }
                    else {
                        PageStatus = false;
                    }
                }
                if (PageStatus) {
                    SelectFieldDropDowndata[positionOfPage].items.push({ id: formId, text: formValues.innerText, items: Items });

                }
                else {
                    fieldsdropDown.treeview.dataSource.add({ id: pageId, text: pageName, items: globaldatasource })

                }
            }

        }
        fieldsdropDown.value('');
    }           
    
}

function ReomveDataInDropDownTree(pageId, formId, Fields) {
   
    var rowCount = $('#tblQueryControl tr').length;
    for (var i = 0; i < rowCount; i++) {
        var fieldsdropDown = $("#Column_"+[i]).data("kendoDropDownTree");
        var SelectFieldDropDowndata = fieldsdropDown.treeview.dataSource.data();

        for (k = SelectFieldDropDowndata.length - 1; k >= 0; k--) {
            if (SelectFieldDropDowndata[k].id == pageId) {
                for (var y = 0; y < SelectFieldDropDowndata[k].items.length; y++) {
                    if (SelectFieldDropDowndata[k].items[y].id == formId) {
                        var fieldsListPresent = SelectFieldDropDowndata[k].items[y].items;
                        for (var m = 0; m < fieldsListPresent.length; m++) {
                            if (fieldsListPresent[m].id == Fields.Id) {

                                var field = fieldsListPresent[m];

                                fieldsdropDown.treeview.dataSource.remove(field);

                            }
                        }

                       
                        if (SelectFieldDropDowndata[k].items[y].items.length == 0) {
                            fieldsdropDown.treeview.dataSource.remove(SelectFieldDropDowndata[k].items[y]);

                        }

                    }
                    //if (SelectFieldDropDowndata[k].items[y].items.length == 0) {
                    //    SelectFieldDropDowndata.remove(SelectFieldDropDowndata[k].items[y]);
                    //}
                }

                if (SelectFieldDropDowndata[k].items.length == 0) {
                    fieldsdropDown.treeview.dataSource.remove(SelectFieldDropDowndata[k]);
                    //SelectFieldDropDowndata.remove(SelectFieldDropDowndata[k]);
                }
            }

        }
    }
}



