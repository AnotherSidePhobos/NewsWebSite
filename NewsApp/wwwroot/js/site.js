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
