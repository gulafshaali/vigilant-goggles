jQuery(document).ready(function ($) {
    //(function ($) {
    var validator, grdAllFields;
    app.modals.AddNewFieldModal = function () {
       
        var _modalManager;
        this.init = function (modalManager) {

            _modalManager = modalManager;

            //--------------PopUp Grid------------------           
             grdAllFields = $("#grdFieldList").kendoGrid({
                dataSource: {                    
                    type: "json",
                    transport: {
                        read: {
                            url: abp.appPath + "App/Fields/GetFieldsList",
                            dataType: "json",
                            type: "GET",
                            data: function () {
                                return {
                                    pageSize: 5,
                                    skip: 0,
                                    Filtertext: $('#txtsearch').val()// send the value of the #search input to the remote service
                                };
                            }
                        },

                    },
                    schema: {

                        data: function (response) {

                            var obj = response.result.data;
                            return obj;
                        },

                        total: function (result) {

                            if (result.result.total) {

                                return result.result.total;
                            }
                            return 0;
                        },

                    },                   
                    serverPaging: true,
                    serverFiltering: true,
                    serverSorting: true,
                    pageSize: 5,                   
                    page: 1,
                },
                sortable: true,
                pageable: {
                    refresh: true,
                    pageSizes: true,
                    buttonCount: 5,

                },
                columns: [
                    { hidden: true, field: "FieldID" },
                    {
                        field: "fieldName",
                        title: "FieldName"

                    },
                    {
                        field: "fieldType",
                        title: "FieldType"
                    },
                    {
                        field: "status",
                        title: "Status"
                    },
                    {
                        field: "Action",
                        title: "Action",
                        template: CheckBox
                    }
                ]
            }).data("kendoGrid");
            $('.k-list-scroller ul:first li:first').remove();
          
        };

        //----------------Add Field on Form-------------
        $("#btnAdd").click(function (e) {
            debugger;
            var rowIndex = j("#hdnRowIndex").val();
            var varFormFieldGrid = j("#grdFormFieldList").data('kendoGrid');
            var varFieldList = j("#grdFieldList").data('kendoGrid');
            var sel = $("input:checked", varFieldList.tbody).closest("tr");
            $.each(sel, function (idx, row) {
         
                var item = varFieldList.dataItem(row);
                var varFieldName = item.fieldName;
                var varFieldType = item.fieldType;
                var varFieldID = item.id;
                var chk = CheckInMainGrid(varFieldName, varFieldType); //----------------Check into main grid------------
                if (chk == false) {
                    if (rowIndex != 0) {
                        varFormFieldGrid.removeRow(varFormFieldGrid.select()); //------- Rmove Row from main grid------
                    }

                    varFormFieldGrid.dataSource.insert(rowIndex, { FieldID: 0, FieldTypeId: varFieldID, FieldName: varFieldName, Type: varFieldType, IsRequired: false, DisplayName: "", PosibleValue: "", ValueFromMaster: "", DefaultValue: "", MaxLengh: "", ShowInGrid: false, IsStatic: false, IncludeInAlert: false });
                }
                else {
                    alert('allready exist...!')
                }


            });
            _modalManager.close();

            j("#hdnRowIndex").val(0);
            varFieldList.refresh();
        });
        //---------------------------reload grid datasource--------------------
        function getFields() {
            grdAllFields.refresh();
            grdAllFields.dataSource.read();
        }
        //---------------------------Filter grid data--------------------
        $('#GetFieldsData').click(function (e) {
            e.preventDefault();
            getFields();
        });
    }

   

    //---------------Check in main grid-------------
    function CheckInMainGrid(varFieldName, varFieldType) {
        var varFormFieldGrid = j("#grdFormFieldList").data('kendoGrid');
        var data = varFormFieldGrid.dataSource.data();
        var setFlag = false;
        j.each(data, function (i, row) {
         
            var mainFIeldName = row.fieldName;
            //var mainFIeldName = row.FieldLable;
            var mainFIeldType = row.FieldType;
            if (mainFIeldName == varFieldName && mainFIeldType == varFieldType) {
                setFlag = true;
            }
        });
        return setFlag;
    }


}); 
