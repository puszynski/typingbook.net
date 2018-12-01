//$(function () {
//    $('.red').click(function () {
//        alert("Działa!");
//    });
//});

function typingBook(currentBookPage) {
    document.onkeypress = function (e) {
        e = e || window.event;

        var nextPage = currentBookPage++;
        var book_content = document.getElementById('book_content').textContent;

        if (String.fromCharCode(e.which /*|| e.keyCode*/) === book_content.charAt(0)) {
            document.body.style.backgroundColor = "dimgray";

            document.getElementById('typed_content').innerHTML += book_content.charAt(0);
            document.getElementById('book_content').innerHTML = book_content.substr(1);

            if (document.getElementById('book_content').innerHTML === '') {
                window.location.href = "?bookID=1&bookPage=@(" + nextPage.toString() + ")"; /* to fix - page*/
            }
        }
        else {
            document.body.style.backgroundColor = "white";
        }
    };
}


var myObject = {
    firstName: "John",
    lastName: "Doe",
    fullName: function () {
        return this.firstName + " " + this.lastName;
    }
}