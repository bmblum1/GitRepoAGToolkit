// Variables used in calculations
// Calculates the fret positions, adds them to an array, and loads them into the table
let scaleCalcData = [];
var numberOfFrets;
var scaleLength;

// Create the HTML table based on the number of frets entered
function createTable() {
    var table = '';
    var rows = document.getElementById('numberOfFretsFormBox').value;
    var cols = 2;
    for (var r = 0; r < rows; r++) {
        table += '<tr>';
        for (var c = 0; c < cols; c++) {
            table += '<td>' + c + '</td>';
        }
        table += '</tr>';
    }
}

// For-loop to loop the calculation and populate the scaleCalcData array []
function calculateAndLoadArray() {
    let location = 0;
    let distance = 0;
    let scalingFactor = 0;
    numberOfFrets = document.getElementById('numberOfFretsFormBox').value;
    scaleLength = document.getElementById('scaleLengthFormBox').value;

    for (i = 0; i < numberOfFrets; i++) {
        var obj = {};

        // Fret distance calculation
        location = scaleLength - distance
        scalingFactor = location / 17.817;
        distance += scalingFactor;

        // Loading the object and pushing to the array
        obj['fret'] = i + 1;
        obj['currentDistance'] = distance.toFixed(3);
        scaleCalcData.push(obj);
    }
}

// Button action event, loads the table and creates it on the page
function buttonCalculation() {
    calculateAndLoadArray();
    loadTableData(scaleCalcData);
    scaleCalcData = [];
}

// Create the table on the webpage
function loadTableData(scaleCalcData) {
    const tableBody = document.getElementById('calculationTableData');
    let dataHtml = '';

    for (let calc of scaleCalcData) {
        dataHtml += `<tr><td>${calc.fret}</td><td>${calc.currentDistance}</td></tr>`;
    }
    console.log(dataHtml)

    tableBody.innerHTML = dataHtml;
}

// Reset Button Logic
function clearForm() {
    document.getElementById("client").reset();
}

// Form Input Validation
(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        var eventList = ["change", "submit", "blur", "invalid", "input"];
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            for (event of eventList) {
                form.addEventListener(event, function (event) {
                    if (form.checkValidity() === false) {
                        event.preventDefault();
                        event.stopPropagation();
                        document.getElementById('calculateButton').disabled = true;
                    }
                    else if (form.checkValidity() === true) {
                        document.getElementById('calculateButton').disabled = false;
                    }
                    form.classList.add('was-validated');
                }, false);
            }
        });
    }, false);
})();
