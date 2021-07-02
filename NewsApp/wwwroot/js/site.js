let likes = document.querySelectorAll('.fa-heart');



console.log(likes);

for (let like of likes) {
    like.addEventListener('click', (e) => {
        let count = like.innerHTML;
        count++;
        like.innerHTML = count;
    });
}