$.noConflict();
var validator, grvAllReport, newDataSource;
var j = jQuery.noConflict();
var _createOrEditModal;

jQuery(document).ready(function ($) {
     _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'App/Fields/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Fields/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditFieldModal'
    });
     
    $('#CreateNewField').click(function () {
        _createOrEditModal.open();
    });


    //----------------------Grid----------------

    //var ff = JSON.parse($("#hdntxt").val());

    //var dd = {
    //    data: ff,
    //    total:"100"
    //}
    //console.log(dd)
   
    //grvMy =$("#gridAllFields").kendoGrid({

    //    columns: [
    //        { hidden: true, field: "id" },
    //        {
    //            title: "S.No",
    //            template: "#= ++record #",
    //            width: 35
    //        },
    //        {
    //            field: "Name",
    //            title: "Field Name",
    //            width: 80
    //        },
    //        {
    //            field: "Type",
    //            title: "Field Type",
    //            width: 80
    //        },
    //        {
    //            field: "Status", template: SetStatus,
    //            title: "Status",
    //            width: 80
    //        },
    //        {
    //            command: [
    //                { name: "edit", text: "", title: "Edit", click: ShowPopUp },
    //                { name: "delete", text: "Delete", title: "Delete", click: showRemoveField }
    //            ],

    //            title: "Action", width: 80
    //        }
    //    ],
    //    dataSource: {
    //        data: dd,
    //        type: "json",
    //        //transport: {
    //        //    read: AllReportDB
    //        //},
    //        schema: {
    //            data: "data",
    //            total: "total",
    //        },
    //    },
    //    //dataSource: {
    //    //    transport: {
    //    //        read: {
    //    //            url: abp.appPath + "App/Fields/GetFieldsList",
    //    //            dataType: "json",
    //    //            type: "GET",
    //    //            data: function () {
    //    //                return {
    //    //                    pageSize: 5,
    //    //                    skip: 0,
    //    //                    Filtertext: $('#txtsearch').val()// send the value of the #search input to the remote service
    //    //                };
    //    //            }
    //    //        },

    //    //    },
    //    //    schema: {

    //    //        data: function (response) {

    //    //            var obj = response.result.data;
    //    //            return obj;
    //    //        },

    //    //        total: function (result) {

    //    //            if (result.result.total) {

    //    //                return result.result.total;
    //    //            }
    //    //            return 0;
    //    //        },

    //    //    },
    //    //    serverPaging: true,
    //    //    serverFiltering: true,
    //    //    serverSorting: true,
    //    //    pageSize: 5,
    //    //    // skip: 2,
    //    //    page: 1,


    //    //},
    //    sortable: true,
    //    pageable: {
    //        refresh: true,
    //        pageSizes: true,
    //        buttonCount: 5,

    //    },


    //    dataBinding: function (e) {


    //        record = (this.dataSource.page() - 1) * this.dataSource.pageSize();
    //    }

    //}).data("kendoGrid");
    
    grvAllReport = $("#gridAllReport").kendoGrid({

        columns: [
            { hidden: true, field: "id" },
            {
                title: "S.No",
                template: "#= ++record #",
                width: 35
            },
            {
                field: "fieldName",
                title: "Field Name",
                 width: 80
            },
            {
                field: "fieldType",
                title: "Field Type",
                width: 80
            },
            {
                field: "status", template: SetStatus,
                title: "Status",
                width: 80
            },
            {
                command: [
                    { name: "edit", text: "", title: "Edit", click: ShowPopUp },
                    { name: "delete", text: "Delete", title: "Delete", click: showRemoveField  }
                ],

                title: "Action", width: 80
            }
        ],
       
        dataSource: {
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
                    
                    var obj =response.result.data;
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
           // skip: 2,
            page: 1,
           
          
            },            
        sortable: true,    
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5,
           
        },
        
       
        dataBinding: function (e) {
           
          
            record = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
        
    }).data("kendoGrid");
    $('.k-list-scroller ul:first li:first').remove();
    

    function getFields() {
        grvAllReport.refresh();
        grvAllReport.dataSource.read();
    }
    abp.event.on('app.createOrEditFieldModalSaved', function () {
        getFields();
    });

    //----------------For Delete Mode----------------
    function showRemoveField(e) {

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
       // alert(dataItem.id + "->" + dataItem.fieldName + "->" + dataItem.fieldType + "->" + dataItem.status);
        e.preventDefault();
        
    }

    //----------------For Edit Mode----------------
    function ShowPopUp(e) {
       
        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        _createOrEditModal.open({ id: dataItem.id });
        //alert(dataItem.id + "->" + dataItem.fieldName + "->" + dataItem.fieldType + "->" + dataItem.status);
        e.preventDefault();
        

    }
    $('#GetFieldsData').click(function (e) {       
        e.preventDefault();        
   getFields();
    });


});










function SetStatus(dataItem) {

    var input = '<span class="m-switch m-switch--sm m-switch--success">  <label class= "mb-0" ><input id=' + dataItem.id + ' onclick="return UpdateStatus(' + dataItem.id + "," + dataItem.status + ')" type="checkbox" /><span></span></label></span>'
    if (dataItem.status == true) {

        input = '<span class="m-switch m-switch--sm m-switch--success"> <label class= "mb-0" > <input type="checkbox" id=' + dataItem.id + '  onclick=" return UpdateStatus(' + dataItem.id + "," + dataItem.status + ')" checked=' + dataItem.status + ' name="">  <span></span></label></span>';
    }
    return input;
}
function UpdateStatus(obj, e)
{
    var _fieldsService = abp.services.app.fields;
  
    var StatusFlag = "false";  
    var status = $("#" + obj).is(':checked'); 
    if (status == true) {
        StatusFlag = "true";
    }
   
    abp.ui.setBusy();
   

    var mydata = {
        Id: obj,
        Status: StatusFlag
    };
    _fieldsService.updateStatus({
        input: mydata,

    }).done(function () {
        abp.ui.clearBusy();
        grvAllReport.dataSource.read();
        grvAllReport.refresh();
        abp.notify.info(app.localize('UpdatedSuccessfully'));
      
        abp.event.trigger('app.createOrEditFieldModalSaved');
    }).always(function () {
        abp.ui.clearBusy();
    });
}