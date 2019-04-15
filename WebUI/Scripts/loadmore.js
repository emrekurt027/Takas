$(function () {

    $("#moreproduct").click(function () {

        var lastid = $(this).attr("data-lastid");
        var _data = {

            lastid: lastid
        }
        $(".moreitemactions").addClass("inprogress");
        $.ajax({
            url: "/Product/LoadMoreProduct",
            type: "POST",
            data: _data,
            complete: function () {
                $(".moreitemactions").removeClass("inprogress");
            }, success: function (d) {
                console.log("success")
                $("#productarea").append(d);


            }, error: function (d) {
                console.log(data);
            }

        });


    });


});