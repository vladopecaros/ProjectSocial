var ButtonId;

window.onload = function () {
    document.getElementById("ProblemDiv").style.display = "none";
    document.getElementById("NewPostDiv").style.display = "none";
}


function DissableEnable(ButtonId) {
    
    if (ButtonId == 1) {
        if (document.getElementById("ProblemDiv").style.display == "none") {

            document.getElementById("ProblemDiv").style.display = "block";

        } else {
            document.getElementById("ProblemDiv").style.display = "none";
        }
    } else if (ButtonId == 2) {
        if (document.getElementById("NewPostDiv").style.display == "none") {
            document.getElementById("NewPostDiv").style.display = "block";
        } else {
            document.getElementById("NewPostDiv").style.display = "none";
        }
    }

}