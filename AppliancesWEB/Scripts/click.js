var burger = document.querySelector('.mobile-nav');
var mobilemenu = document.querySelector('#burger');
var mobilemenumain = document.querySelector('.mobile-menu-header');

burger.onclick = function () {
    $(".m-nav-container").slideToggle();
};