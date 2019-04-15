$(function () {

    $("#moreproduct").click(function () {
        console.log("moar");
        var lastid = $(this).attr("data-lastid");
        var _data = {

            lastid: lastid
        }
        $(".moreitemactions").addClass("inprogress");
        $.ajax({
            url: "/Product/LoadMoreProduct",
            type: "GET",
            data: _data
        }).done(function (data) {

            if (data.indexOf('div') == -1) {
                $(".moreitemactions").remove();
                return;
            }

            $(".moreitemactions").removeClass("inprogress");
            $('#productarea').append(data);
            let lastId = $(data).find('a').last().attr('data-pid');
            $('#moreproduct').attr('data-lastid', lastId);

        }).fail(function (err) {
            $(".moreitemactions").removeClass("inprogress");
            console.log(err);
        });

    });


});