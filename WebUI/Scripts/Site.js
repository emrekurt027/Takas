
$(function () {

    $("#SignButton").on("click", function () {
        console.log("tıkladım")
        $.ajax({
            url: "/Home/LoginPopup", type: "POST", success: function (d) {

                $(".body-content").append(d);
                $("#LogModal").modal("show");
            }
        })
        $(".body-content").on("hide.bs.modal", ".wmodal", function () {

            $(this).remove();

        })

    })


    $(document).ready(function () {
        $('.pass_show').append('<span class="ptxt">Show</span>');
    });


    $(document).on('click', '.pass_show .ptxt', function () {

        $(this).text($(this).text() == "Show" ? "Hide" : "Show");

        $(this).prev().attr('type', function (index, attr) { return attr == 'password' ? 'text' : 'password'; });

    });  

})