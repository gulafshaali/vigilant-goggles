jQuery(document).ready(function ($) {
//(function ($) {
    var validator;
    app.modals.CreateOrEditFieldModal = function () {
        var _fieldsService = abp.services.app.fields;
        var _$fieldEditForm = null;
        var _modalManager;
        this.init = function (modalManager) {
        
            _modalManager = modalManager;
            _$fieldEditForm = _modalManager.getModal().find('form[name=CreateFieldForm]');
            //var IsEditMode = _modalManager.getModal().find('input[name=Id]');
           
             //-----------------Validation------------------
            validator = $("#CreateFieldForm").kendoValidator({
                rules: {
                    Custom1: function (input) {
                        if (input.is("[name=FieldName]")) {
                            var maxlength = 70;
                            var minlength = 3;
                            var value = input.val();
                            return (value.replace(/<[^>]+>/g, "").length >= minlength && value.replace(/<[^>]+>/g, "").length <= maxlength);


                        }

                        return true;
                    },

                    dropdown: function (input) {
                        if (input.is("[name='FieldType']")) {
                            var dropdownlist = input.data("kendoDropDownList");
                            if (!dropdownlist.value()) {
                                return false;
                            }
                        }
                        return true;
                    },
                    radio: function (input) {

                        if (input.filter("[type=radio]") && input.attr("required")) {
                            return $("#CreateFieldForm").find("[type=radio]").is(":checked");
                        }
                        return true;



                    },
                },
                messages: {
                   radio: "Please Select Status",
                    dropdown: "Please select Field Type",
                    Custom1: "Field Name must have length greater than 3 and less than 70"
                }
            }).data("kendoValidator");

            //----------------Field Type---------------
           var fieldTypeDropDown= $("#txtFiedlType").kendoDropDownList({
                //dataSource: {
                //    transport: {
                //        read: {
                //            url: $("#siteUrl").val() + "Mpa/SuperAdmin/GetTheme",
                //            dataType: "json"
                //        },

                //    },
                //    sort: { field: "ThemeName", dir: "asc" }
                //},

                dataTextField: "text",
                dataValueField: "value",
                dataSource: [
                    { text: "Text Box", value: "1" },
                    { text: "Text Area", value: "2" },
                    { text: "Text Editor", value: "3" },
                    { text: "URL", value: "4" },
                    { text: "Attachment", value: "5" },
                    { text: "Drop Down", value: "6" },
                    { text: "MultiSelect", value: "7" },
                    { text: "Radio", value: "8" },
                    { text: "Date Picker", value: "9" }

                ],
               //filter: "startswith",
                optionLabel: "Select"
            }).data("kendoDropDownList");
            
           
            if ($("#hdnFieldType").val() != null) {
               
                fieldTypeDropDown.value($("#hdnFieldType").val());
            }
            $("#textFieldName").on("keypress", function (e) {
                if (e.which === 32 && !this.value.length)
                    e.preventDefault();
            });
            $("#txtFiedlType").on("keypress", function (e) {
                if (e.which === 32 && !this.value.length)
                    e.preventDefault();
            });
        };

      
         //--------------------Save Record--------------
        $("#btnSave").click(function (e) {
           
            if (validator.validate()) {
               // var radioValue = $("input[name=" + "Status" + "]:checked").val();              
                var FieldsInput = _$fieldEditForm.serializeFormToObject();              
                _modalManager.setBusy(true);
                _fieldsService.createOrUpdateFields({
                    input: FieldsInput,                    
                }).done(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    _modalManager.close();
                   abp.event.trigger('app.createOrEditFieldModalSaved');
                }).always(function () {
                    _modalManager.setBusy(false);
                });                
            }
            else {
                
            }
        });
        $("#btnAddMore").click(function (e) {
            if (validator.validate()) {
               // var radioValue = $("input[name=" + "Status" + "]:checked").val();
                var FieldsInput = _$fieldEditForm.serializeFormToObject();              
                _modalManager.setBusy(true);
                _fieldsService.createOrUpdateFields({
                    input: FieldsInput,
                }).done(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));                   
                    document.getElementById("CreateFieldForm").reset();                  
                    abp.event.trigger('app.createOrEditFieldModalSaved');
                }).always(function () {
                    _modalManager.setBusy(false);
                });

            }
            else {

            }
        });

       
    }

   
   
   


}); 







