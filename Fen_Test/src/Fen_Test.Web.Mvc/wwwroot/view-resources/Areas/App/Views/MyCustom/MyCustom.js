

(function () {
    $(function () {
       

        //-Uncomment these lines when calling through view Component
        $(".m-menu__link1").click(function ()
        {           
           $("#searchResults").empty();
            var tst = $(this).attr('data-test');   
            $("#searchResults").load(abp.appPath + 'App/MyCustom/MyCustomSideBar/' + tst);
        });




       


    });

})();


