// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function mainPageMenuShortcuts(spaceLink, shiftLink, escLink) {

    document.onkeydown = function (event) {
        //ToDo - ukryty tekst dla niewidomych który mówi aby nacisnąć 'B' aby przejść do trybu dla niewidomych + event
        if (event.keyCode === 32) {
            window.location.href = spaceLink;
        }
        if (event.keyCode === 16) {
            window.location.href = shiftLink; // name?
        }
        if (event.keyCode === 27) {
            window.location.href = escLink; // ?
        }
    };
}


function typingBook(currentBookPage, bookPagesJson, isIntroduction) {
    document.onkeypress = function (e) {
        e = e || window.event;

        var book_content = document.getElementById('book_content').textContent;
        pageLength = bookPagesJson[currentBookPage].length;

        //typing
        if (String.fromCharCode(e.which /*|| e.keyCode*/) === book_content.charAt(0)) {
            var decreasedValue = parseInt($(".correctTyped").text(), 10) + 1;
            $('.correctTyped').html(decreasedValue);

            updateBookPageStatusBar(pageLength);

            document.body.style.backgroundColor = "dimgray";
            document.getElementById('typed_content').innerHTML += book_content.charAt(0);
            document.getElementById('book_content').innerHTML = book_content.substr(1);

            
            if (document.getElementById('book_content').innerHTML === '') {
                //when book pages end
                var bookPages = bookPagesJson;
                var nextPage = ++currentBookPage;

                saveBookPageProgress();
                saveStatisticsProgress();

                $('.progress-bar-correct').css({ 'width': '0%' });
                $('.progress-bar-wrong').css({ 'width': '0%' });
                $('.correctTyped').html('0');
                $('.wrongTyped').html('0');

                if (bookPages.length <= nextPage) {
                    if (isIntroduction === 1) {
                        window.location.href = '?bookID=2&bookPage=0';
                    }
                    else {
                        window.location.href = '@Url.Action("Index", "Books")';
                        //redirectToAction();
                    }
                }
                else {
                    document.getElementById('typed_content').innerHTML = '';
                    document.getElementById('book_content').innerHTML = bookPages[nextPage];
                }
            }
        }
        else {
            var increasedValue = parseInt($(".wrongTyped").text(), 10) + 1;
            $('.wrongTyped').html(increasedValue);

            document.body.style.backgroundColor = "white";
            updateBookPageStatusBar(pageLength);
        }
    };
}


function updateBookPageStatusBar(pageLength) {
    var correctTyped = parseInt($(".correctTyped").text(), 10);
    var wrongTyped = parseInt($(".wrongTyped").text(), 10);

    var correctPercent = correctTyped / (pageLength + wrongTyped) * 100;
    var wrongPercent = wrongTyped / (pageLength + wrongTyped) * 100;

    $('.progress-bar-correct').css({ 'width': correctPercent + '%' });
    $('.progress-bar-wrong').css({ 'width': wrongPercent + '%' });
}

function saveBookPageProgress() {
    var url = '/Statistics/SaveBookPageProgress';

    $.ajax({
        url: url,
        data: { // TODO
            input: "razdwatrzy"
        },
        type: 'GET',
        datatype: 'json'
    });
}


function saveStatisticsProgress() {
    var url = '/Statistics/SaveStatisticProgress';
    
    var correctTyped = parseInt($(".correctTyped").text(), 10);
    var wrongTyped = parseInt($(".wrongTyped").text(), 10);

    $.ajax({
        url: url,
        data: { // TODO
            correctTyped: correctTyped,
            wrongTyped: wrongTyped
        },
        type: 'GET',
        datatype: 'json',
        //success: function () {
        //    alert("Data has been added successfully.");  
        //    LoadData();
        //},
        //error: function () {
        //    alert("Error while inserting data");
        //}
    });
}


// TODO
function redirectToAction() {
    var url = '/Books/Index/';
    $.ajax({
        url: url,
        data: {
            //parameters go here in object literal form
            param1: xyz,
            param2: 123
        }, 
        type: 'GET',
        datatype: 'json',
        success: function (data) {
            //tu chyba musi być przekierowanir
            alert('got here with data');
            window.location.href = data.redirecturl;

        },
        error: function () { alert('something bad happened'); }
    });
}


// inny przkład:
//function fungo() {
//    var date = new Date(); // Javascript date object 
//    var link = '@Url.Action("ActionMethod", "Home")';  // url should be enclosed by single quotes.
//    var args = {
//        param1: date.toISOString(),  // make sure that the date is in Javascript date object and converted to ISO string for proper casting in c#
//        param2: date.toISOString(),
//        param3: 'somevalue'
//    };

//    $.ajax({
//        type: "GET",
//        url: link, // url of your action
//        data: args, // parameters if available 
//        dataType: "json",
//        success: function (data) {

//            window.location.href = data.redirecturl; // your action should return an object having [redirecturl] property

//        },
//        error: function (httpRequest, textStatus, errorThrown) {  // detailed error messsage 
//            alert("Error: " + textStatus + " " + errorThrown + " " + httpRequest);
//        }
//    });

//}
