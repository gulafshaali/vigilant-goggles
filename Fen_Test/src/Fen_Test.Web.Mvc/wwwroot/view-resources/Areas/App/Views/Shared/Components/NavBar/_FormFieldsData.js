
$.noConflict();

       jQuery(document).ready(function () {
           
        try {
            
            //var dataSource1 = new kendo.data.DataSource({
            //    data: [
            //        { id: 1, item: "Item 1" },
            //        { id: 2, item: "Item 2" },
            //        { id: 3, item: "Item 3" },
            //        { id: 4, item: "Item 4" },
            //        { id: 5, item: "Item 5" },
            //        { id: 6, item: "Item 6" },
            //        { id: 7, item: "Item 7" },
            //        { id: 8, item: "Item 8" },
            //        { id: 9, item: "Item 9" },

            //    ],
            //});
      
            $("#fieldValues").kendoListBox({

                connectWith: "selectedFields",
                toolbar: {
                    tools: ["transferTo", "transferFrom", "transferAllTo", "transferAllFrom"]
                },
               // dataSource: dataSource1,
                //template: "<div>#: item #</div>",
            });

            $("#selectedFields").kendoListBox({
                //template: "<div>#: item #</div>",
            });
        }
        catch (e) {
            alert(e.message);
        }







    });

