'use strict';

let authorDropdown = document.getElementById("AuthorsDropdown");
let authorsFirstName = document.getElementById("AuthorsFirstName");
let authorsLastName = document.getElementById("AuthorsLastName");

let seriesDropdown = document.getElementById("SeriesDropdown");
let seriesName = document.getElementById("SeriesName");

authorDropdown.addEventListener("change", function () {
    if (authorDropdown.value !== '0') {
        alert("Bang!");
        authorsFirstName.value = '';
        authorsFirstName.disabled = true;
        authorsLastName.value = '';
        authorsLastName.disabled = true;
    }
    else {
        authorsFirstName.disabled = false;
        authorsLastName.disabled = false;
    }
});

seriesDropdown.addEventListener("change", function () {
    if (seriesDropdown.value !== '0') {
        alert("Bang!");
        seriesName.value = '';
        seriesName.disabled = true;
    }
    else {
        seriesName.disabled = false;
    }
});