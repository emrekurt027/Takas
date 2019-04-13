$(function () {


    $('#searchProduct').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Product/SearchProduct',
                data: { term: request.term }
            }).done(function (data) {
                console.log("success search product")
                var nameList = JSON.parse(data).map(item => {
                    return { label: item.Name, value: item.Name, id: item.Id }
                });
                response(nameList);


                }).fail(function (data) {
                    console.log(data);
            });
               
            
        },
        minLength: 3,
        select: function (event, ui) {

            window.location.href = "http://localhost:50843/Product/Details/" + ui.item.id;

        }
    });


});