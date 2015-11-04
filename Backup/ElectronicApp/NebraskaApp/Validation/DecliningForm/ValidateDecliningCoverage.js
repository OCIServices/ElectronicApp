function valSubmit() {
    var rval = false;
    var checkboxes = document.getElementsByName("UserWizard1$Dental");
    var c = checkboxes.length;  
    var i = 0;
    var numchecked = 0;
    
    for (i; i < c; ++i) {
//        if (checkboxes[i].type == "checkbox") {
            if (checkboxes[i].checked)
            {
                rval = true;
                numchecked++;
            }
//        }
    }
    if (!rval || numchecked > 1 ) {
        alert("Please select a reason for declining coverage.");
    }

    
try{
    if ( document.getElementById("UserWizard1_RadioButton40") && document.getElementById("UserWizard1_RadioButton40").checked && !validateRequired(document.getElementById("UserWizard1_TextBox4").value) ) {
        alert("Please enter an explanation.");
        rval = false;
    }
}
catch (e) {};

try{
    if ( document.getElementById("UserWizard1_RadioButton30") && document.getElementById("UserWizard1_RadioButton30").checked && !validateRequired(document.getElementById("UserWizard1_TextBox3").value) ) {
        alert("Please enter an explanation.");
        rval = false;
    }
}
catch (e){};

try{
    if ( document.getElementById("UserWizard1_ckOther") && document.getElementById("UserWizard1_ckOther").checked && !validateRequired(document.getElementById("UserWizard1_txtExplanation").value) ) {
        alert("Please enter an explanation.");
        rval = false;
    }
}
catch (e){}
    
    
    return rval;
}