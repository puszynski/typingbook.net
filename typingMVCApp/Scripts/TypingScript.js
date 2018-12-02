
function spaceScrollDisable() {
    $(document).keydown(function (e) {
        if (e.which === 32) {
            return false;
        }
    });
}


function mainPageMenuShortcuts() {
    document.onkeydown = function (event) {
        if (event.keyCode === 32) {
            window.location.href = '@Url.Action("Index", "Typing")';
        }
        if (event.keyCode === 16) {
            window.location.href = '@Url.Action("ChoseBook", "Home")'; // name?
        }
        if (event.keyCode === 27) {
            window.location.href = '@Url.Action("Settings", "Home")'; // ?
        }
        //ToDo - ukryty tekst dla niewidomych który mówi aby nacisnąć 'B' aby przejść do trybu dla niewidomych + event
    };
}

function typingBook(currentBookPage, bookPagesJson, isIntroduction) {
    document.onkeypress = function (e) {
        e = e || window.event;
        
        var book_content = document.getElementById('book_content').textContent;

        if (String.fromCharCode(e.which /*|| e.keyCode*/) === book_content.charAt(0)) {
            document.body.style.backgroundColor = "dimgray";
            document.getElementById('typed_content').innerHTML += book_content.charAt(0);
            document.getElementById('book_content').innerHTML = book_content.substr(1);

            if (document.getElementById('book_content').innerHTML === '') {
                var bookPages = bookPagesJson;
                var nextPage = ++currentBookPage;    

                if (bookPages.length <= nextPage) {
                    if (isIntroduction === 1) { 
                        window.location.href = '?bookID=2&bookPage=0';
                    }
                    else {
                        window.location.href = '@Url.Action("ChoseBook", "Home")';
                    }
                }
                else {
                    document.getElementById('typed_content').innerHTML = '';
                    document.getElementById('book_content').innerHTML = bookPages[nextPage];
                }
            }
        }
        else {
            document.body.style.backgroundColor = "white";
        }
    };
}


//fun
var myObject = {
    firstName: "John",
    lastName: "Doe",
    fullName: function () {
        return this.firstName + " " + this.lastName;
    }
};