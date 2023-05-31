    $(document).ready(function () {
        $("#btnsubmit1").click(function (e) {
            //Serialize the form datas.
            var valdata = $("#formmethod1").serialize();
            //to get alert popup
            $.ajax({
                url: "/Customers/Index",
                type: "POST",
                dataType: 'json',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: valdata
            });
        });
        });
