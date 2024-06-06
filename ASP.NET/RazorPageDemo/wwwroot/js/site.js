// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var linesPerPage = 10;
var currentPage  = 1;
var pages = 0;



function clickPaginator() {
    if (this.innerHTML == "<<") {
        currentPage = 1;
        fillTable();
        return;
    }
    if (this.innerHTML == ">>") {
        currentPage = pages;
        fillTable();
        return;

    }
    currentPage = Number(this.innerHTML);
    fillTable();
}

function clickRow() {
    let items = document.getElementsByClassName("selectedRow");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("selectedRow");
    }



    this.classList.add("selectedRow");
}

function fillTable() {
    let idNomrnclatureTBody = "nomenclatureTBody";
    let xhr = new XMLHttpRequest();
    let url = '/api/nomenclatures?skip=' + ((currentPage - 1) * linesPerPage) + '&take=' + linesPerPage;
    xhr.open('GET', url);
    xhr.responseType = 'json';
    xhr.onload = function () {
        let status = xhr.status;
        if (status == 200) {
            let data = xhr.response;
            let count = data.count;
            let tb = document.getElementById(idNomrnclatureTBody);
            tb.innerHTML = null;
            for (let i = 0; i < data.nomenclatures.length; i++) {
                let tr = document.createElement('tr');
                let id = "id" + data.nomenclatures[i].id;
                tr.id = id;
                tr.onclick = clickRow;
                tb.appendChild(tr);
                let tdName = document.createElement('td');
                tdName.innerHTML = data.nomenclatures[i].name;
                tr.appendChild(tdName);
                let tdPrice = document.createElement('td');
                tdPrice.innerHTML = data.nomenclatures[i].price;
                tr.appendChild(tdPrice);

            }

            pages = Math.trunc(count / linesPerPage) + ((count % linesPerPage) == 0 ? 0 : 1)
            let paginator = document.getElementById('paginatorId');
            paginator.innerHTML = null;
            for (let i = 1; i <= pages; i++)
            {
                let liElement = document.createElement('li');
                liElement.classList.add("page-item");
                if (currentPage == i)
                    liElement.classList.add("active");

                paginator.appendChild(liElement);
                aElement = document.createElement('button');
                aElement.classList.add("page-link");
               
                aElement.onclick = clickPaginator;
                aElement.innerHTML = i;
                liElement.appendChild(aElement);
            }




        }
    }
    xhr.send();

}