$(function () {

    $(document).on('click', '#login-button', function () {
        console.log("LOGINSTART");
        var loginData = {
            UserName: $('#email-box').val(),
            Password: $('#password-box').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Account/Login',
            data: loginData
        }).done(function (jsonData) {
            console.log("YEP LOGIN");
            var data = JSON.parse(jsonData);
            if (data.error) {
                console.log(data.error_description);
                return;
            }

            location.reload();

        }).fail(function (err) {
            console.log("ERROR LOGIN");
        });
    });

    const googleApiKey = "AIzaSyBa7OgoT4bsgFx55phsuNjLptOU8ELvAUo";

    $('#booksAutoComplete').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "https://www.googleapis.com/books/v1/volumes",
                type: "GET",
                data: {
                    q: request.term,
                    maxResults: 10,
                    fields: "items(id,volumeInfo(title))",
                    key: googleApiKey
                }
            }).done(function (data) {
                var titleList = data.items.map(item => {
                    return { label: item.volumeInfo.title, value: item.volumeInfo.title, id:item.id}
                });
                console.log("yep google api books");
                response(titleList);
            }).fail(function (data) {
                console.log("error google api books");
            });
        },
        minLength:3,
        select: function (event, ui) {

            $.ajax({
                url: "https://www.googleapis.com/books/v1/volumes/"+ui.item.id,
                type: "GET",
                data: {
                    fields: "volumeInfo(authors,categories,description,imageLinks,title)",
                    key: googleApiKey
                }
            }).done(function (data) {
                console.log(data);
                let bookInfo = data.volumeInfo;
                $('#userId').val("1");//todo: kullanıcı id'si elle veriliyor şimdilik, düzeltilecek.
                $('#authorName').val(bookInfo.authors[0]);
                //gelen açıklamada html kodları da oluyor, çıkarılmazsa post işleminde hata alınıyor, replace işlemi bunun için var.
                $('#description').val(bookInfo.description.replace(/(<([^>]+)>)/ig, ""));
                $('#imageUrl').val(bookInfo.imageLinks.thumbnail);
                $('#categories').val(bookInfo.categories.join(','));

            }).fail(function (data) {
                console.log("error google api books : get by book id");
            });

        }
    });

});