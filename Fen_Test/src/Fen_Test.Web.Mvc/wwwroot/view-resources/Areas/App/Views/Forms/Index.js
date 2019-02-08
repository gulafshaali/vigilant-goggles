$.noConflict();
var j = jQuery.noConflict();
var tempSavedRecords = null;

var RowTransfar, SelectedRow;
var _AddNewFieldModal;
jQuery(document).ready(function ($) {
    _AddNewFieldModal = new app.ModalManager({
        viewUrl: abp.appPath + 'App/Form/AddFormFields',
        scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Forms/_AddFormFields.js',
        modalClass: 'AddNewFieldModal'
    });
    $('#AddNewField').click(function () {

        _AddNewFieldModal.open();
    });
    AllReportDB =
        {
           // total: 5,
            data: [
               // {
            //        FieldID: 1,
            //        FieldTypeId: 9,
            //        FieldLable: "FirstName",
            //        Type: "TextBox",
            //        IsRequired: false,
            //        DisplayName: "Given Name",
            //        PosibleValue: "",
            //        ValueFromMaster: "",
            //        DefaultValue: "Blank",
            //        MaxLengh: "25",
            //        ShowInGrid: true,
            //        IsStatic: false,
            //        IncludeInAlert: true
             //   },
               
            ]
        }

  

    var grvAllReport = $("#grdFormFieldList").kendoGrid({
        dataSource: {
            data: AllReportDB,
            type: "json",
            //transport: {
            //    read: AllReportDB
            //},
            schema: {
                data: "data",
                total: "total",
            },
        },
        noRecords: true,
        edit: gridCellEdit,
        selectable: "cell",
        change: onChange,
        sortable: true,
        pageable: false,
        columns: [
            { hidden: true, field: "FieldID" },
            { hidden: true, field: "FieldTypeId" },
            {
                //field: "FieldLable",
                field: "FieldName",
                title: "FieldLable",

            },
            {
                field: "Type",
                title: "Type"
            },
            {
                field: "IsRequired", template: CheckBox,
                title: "IsRequired"
            },
            {
                field: "DisplayName",
                title: "DisplayName"
            },
            {
                field: "PosibleValue",
                title: "PosibleValue"
            },
            {
                field: "ValueFromMaster",
                title: "ValueFromMaster"
            },
            {
                field: "DefaultValue",
                title: "DefaultValue"
            },
            {
                field: "MaxLengh",
                title: "MaxLengh"
            },
            {
                field: "ShowInGrid", template: ShowInGrid,
                title: "ShowInGrid"
            },
            {
                field: "IsStatic", template: IsStatic,
                title: "IsStatic"
            },
            {
                field: "IncludeInAlert", template: IncludeInAlert,
                title: "IncludeInAlert"
            },
            {
                command: [
                    { name: "edit", text: "", title: "edit" },
                    { template: "<button class='remove k-button'>Remove</button>" }
                ],

                title: "Action", width: 110
            }
        ],
        editable: "inline",
        save: function (e) {
            // updateTempRecords();  //----------For Remove Edit Box-----------
            var tem = $('#grdFormFieldList').data('kendoGrid').dataSource.data();
            tem = tem.toJSON();
            $('#grdFormFieldList').data('kendoGrid').dataSource.data(tem);
        },
        noRecords: true
    }).data("kendoGrid");

    //-------------Remove Row from Grid--------------
    $("#grdFormFieldList").on("click", "button.remove", function () {
        var $tr = $(this).closest("tr"),
            grid = $("#grdFormFieldList").data("kendoGrid");
        grid.removeRow($tr);
    });

   

  

});

function onChange(e) {
    //var grid = j("#grdFormFieldList").data("kendoGrid");
    //var row = this.select().closest("tr");
    //debugger;
    //if (row.find("td:eq(2)").hasClass('k-state-selected')) {
    //    //------- Check Column number----------
    //    var AllCheckBox = j("input:checkbox", row).closest("tr");
    //    var varIsStatic = AllCheckBox.prevObject[2];
    //    //---------Get checkbox by index in grid-------
    //    if (varIsStatic.checked != true) {
    //        //------------Check Is static-------------
    //        SelectedRow = row;
    //        var rowIdx = j("tr", grid.tbody).index(row);
    //        j("#hdnRowIndex").val(rowIdx);          
    //        _AddNewFieldModal.open();
    //    }
    //}
}



function CheckBox(e) {
    var input = '<input type="checkbox"  id=' + e.FieldID + ' name="selectField"  Ischecked="false" />'
    if (e.IsRequired == true) {
        input = '<input type="checkbox" id=' + e.FieldID + ' name="selectField" Ischecked="true" />';
    }

    return input
}


//------------------Disable Edit in main grid-----------------------
function gridCellEdit(e) {
    //e.container.find("input[name='FieldLable']").each(function () { $(this).attr("disabled", "disabled") });
    e.container.find("input[name='fieldName']").each(function () { $(this).attr("disabled", "disabled") });
    e.container.find("input[name='Type']").each(function () { $(this).attr("disabled", "disabled") });
}
function ShowInGrid(e) {
    var input = '<input type="checkbox" name="ShowInGridn"  id=' + e.FieldID + '  />'
    if (e.ShowInGrid == true) {
        input = '<input type="checkbox" name="ShowInGridn" id=' + e.FieldID + ' checked="checked" />';
    }

    return input
}
function IsStatic(e) {
    var input = '<input type="checkbox" name="IsStatic" id=' + e.FieldID + '  />'
    if (e.IsStatic == true) {
        input = '<input type="checkbox" name="IsStatic" id=' + e.FieldID + ' checked="checked" />';
    }

    return input
}
function IncludeInAlert(e) {
    var input = '<input type="checkbox" name="IncludeAlert" id=' + e.FieldID + '  />'
    if (e.IncludeInAlert == true) {
        input = '<input type="checkbox" name="IncludeAlert" id=' + e.FieldID + ' checked="checked" />';
    }

    return input
}

