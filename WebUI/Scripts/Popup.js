$(function () {

    $("#SignButton").on("click", function () {
        console.log("tıkladım")
        $.ajax({
            url: "/Home/LoginPopup", type:"Post", success: function(d) {

                $(".body-content").append(d);
                $("#LogModal").modal("show");
            }
        })
        $(".body-content").on("hide.bs.modal", ".wmodal", function () {

            $(this).remove();

        })

    })
})