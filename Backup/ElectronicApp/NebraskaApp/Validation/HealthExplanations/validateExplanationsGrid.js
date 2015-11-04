function valSubmit() {

    if ( document.getElementById("UserWizard1_NumExplanationsRequired").value == "0" ) {
        return true;
    }
    
    else {
        alert("There isn't an explanation for each condition listed!\n\nPlease list an explanation for each condition.");
        return false;
    }

}