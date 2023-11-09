$(() => {
    function search() {
        var input = document.getElementById("searchTerm");
        var filter = input.value.toUpperCase();
        var table = document.getElementById("data-table");
        var rows = table.getElementsByTagName("tr");
        for (var i = 1; i < rows.length; i++) {
            var cells = rows[i].getElementsByTagName("td");
            var found = false;
            for (var j = 0; j < cells.length; j++) {
                var cellText = cells[j].textContent || cells[j].innerText;
                if (cellText.toUpperCase().indexOf(filter) > -1) {
                    found = true;
                    break;
                }
            }
            rows[i].style.display = found ? "" : "none";
        }
    }

    var searchInput = document.getElementById("searchTerm");
    searchInput.addEventListener("keyup", search);




})