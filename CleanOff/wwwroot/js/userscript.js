/* global bootstrap: false */

//(() => {
//    'use strict'
//    const tooltipTriggerList = Array.from(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
//    tooltipTriggerList.forEach(tooltipTriggerEl => {
//        new bootstrap.Tooltip(tooltipTriggerEl)
//    })
//})()

//function switchForm(n) {
//    var forms = document.getElementsByClassName("form-container");
//    for (var i = 0; i < forms.length; i++) {
//        forms[i].classList.add("d-none");
//    }
//    forms[n].classList.remove("d-none");
//}

function switchF1() {
    document.getElementById("what").style.display = "block";
    document.getElementById("orders").style.display = "none";
    document.getElementById("make").style.display = "none";
    document.getElementById("profile").style.display = "none";
}

function switchF2() {
    document.getElementById("what").style.display = "none";
    document.getElementById("orders").style.display = "block";
    document.getElementById("make").style.display = "none";
    document.getElementById("profile").style.display = "none";
}

function switchF3() {
    document.getElementById("what").style.display = "none";
    document.getElementById("orders").style.display = "none";
    document.getElementById("make").style.display = "block";
    document.getElementById("profile").style.display = "none";
}

function switchF4() {
    document.getElementById("what").style.display = "none";
    document.getElementById("orders").style.display = "none";
    document.getElementById("make").style.display = "none";
    document.getElementById("profile").style.display = "block";
    return false;
}

function aaaF() {
    alert("HER");
}

