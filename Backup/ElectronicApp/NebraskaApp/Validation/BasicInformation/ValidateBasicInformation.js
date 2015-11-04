
function cmbWaiverChange() {
        if (document.getElementById("UserWizard1_cmbWaive").value == "Yes") {
            alert("By waiving all coverage at this time you understand that you and any dependents will not be able to participate unless you experiance a life change event, at the next open enrollment or as a late enrollee if applicable.");
        }
}

function valSubmit() {
    rval = true;
    if (!validateRequired(document.getElementById("UserWizard1_txtFirstName").value)) {
        alert("Please enter your first name");
        rval = false;
    }
    else if (!validateRequired(document.getElementById("UserWizard1_txtLastName").value)) {
        alert("Please enter your last name");
        rval = false;
    }
    else if (!validateDate(document.getElementById("UserWizard1_txtMonth").value + "/" + document.getElementById("UserWizard1_txtDay").value + "/" + document.getElementById("UserWizard1_txtYear").value)) {
        alert('Please enter valid birth date (mm/dd/yyyy)');
        rval = false;
    }
    else if ( document.getElementById("UserWizard1_cmbWaive").value == "(Select)" ) {
        alert("Please select whether you want to decline all coverage");
        rval = false;
    }
    
    return rval;
}