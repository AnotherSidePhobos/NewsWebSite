let likes = document.querySelectorAll('.fa-heart');




for (let like of likes) {
    like.addEventListener('click', (e) => {
        let count = like.innerHTML;
        count++;
        like.innerHTML = count;
    });
}



let logoName = document.querySelector('.nameOfUser');
console.log(logoName);


var routeURL = location.protocol + "//" + location.host;
function openFeedBackWind() {
    $("#feedBackInput").modal("show");
}



function onCloseModal() {

    $("#feedBackInput").modal("hide");
}

function onSubmitForm() {
    var requestData = {
        Id: parseInt($("#id").val()),
        Comment: $("#comment").val(),
        Author: $("#author").val()
    };

    $.ajax({
        url: routeURL + '/FeedBack/SaveFeedBack',
        type: 'POST',
        data: JSON.stringify(requestData),
        contentType: 'application/json'

    });
    onCloseModal();
}



let links = document.querySelectorAll('.links a'),
    ind = document.querySelector('.indicator');

links.forEach(item => {
    item.addEventListener('mouseenter', (e) => {
        moveInd(e.target);
    });
});

function moveInd(el) {
    ind.style.width = `${el.offsetWidth}px`;
    ind.style.left = `${el.offsetLeft}px`;
}



let searching = function () {
    
    let titles = document.querySelectorAll('#filter_list');

}


//let filter = function () {
//    let input = document.querySelector('#filter_input');

//    input.addEventListener('keyup', function () {
//        let filter = input.value.toLowerCase(),
//            filterElements = document.querySelectorAll('#filter_list li');

//        filterElements.forEach(item => {
//            if (item.innerHTML.toLocaleLowerCase().indexOf(filter) > -1) {
//                item.style.display = '';
//            }
//            else {
//                item.style.display = 'none';
//            }
//        })
//    });

//}

//filter();