var burger = document.querySelector('.mobile-nav');
var mobilemenu = document.querySelector('#burger');
var mobilemenumain = document.querySelector('.mobile-menu-header');

burger.onclick = function(){
    mobilemenu.classList.toggle('mobile-nav-after');
    mobilemenumain.classList.toggle('mobile-nav-header-after');
};