function valSubmit() {

    rval = false;
   // if (!(document.getElementById("cmbCoverage").value == "(Select)")) {
    //    if (document.getElementById("cmbCoverage").value == "yes") {
    //        return validateWaiveAll();
    //    }
    //    else if (document.getElementById("cmbCoverage").value == "no") {
            return validateNoWaive();
    //    }   
   // }
   // else
     //   alert("please select whether you want to waive all coverage");
        
    //return rval;
}

function validateWaiveAll() {
    var rval = false;

    
    if (!validateRequired(document.getElementById("UserWizard1_txtEmployeeName").value)) {
        alert("Please enter Employee name");
        rval = false;
    }
    else if (!validateDate(document.getElementById("UserWizard1_txtDOB").value)) {
        alert("Please enter valid Date of Birth (mm/dd/yyyy)");
        rval = false;
    }
    else
        rval = true;

    return rval;
}

function validateNoWaive() {
    var rval = true;
    document.getElementById("Validation").style.display = "none";
    document.getElementById("ErrorListRight").innerHTML = "";
    document.getElementById("ErrorListLeft").innerHTML = "";
    
    if (!validateRequired(document.getElementById("UserWizard1_txtEmployeeName").value)) {
        //alert("Please enter Employee name");
        insertErrorLeft("Please enter Employee name");
        rval = false;
    }
    if (!validateRequired(document.getElementById("UserWizard1_txtAddress").value)) {
       // alert("Please enter Home Address");
        insertErrorLeft("Please enter Home Address");
        rval = false;
    }
    if (!validateRequired(document.getElementById("UserWizard1_txtCity").value)) {
       // alert("Please enter City");
        insertErrorLeft("Please enter City");
        rval = false;
    }
    if (!validateRequired(document.getElementById("UserWizard1_txtState").value)) {
       // alert("Please enter State");
        insertErrorLeft("Please enter State");
        rval = false;
    }
    if (!validateZip(document.getElementById("UserWizard1_txtZip").value)) {
        //alert("Please enter Zip");
        insertErrorLeft("Please valid ZIP Code");
        rval = false;
    }
    if (!validatePhoneNumber1(document.getElementById("UserWizard1_txtWorkPhone").value, document.getElementById("UserWizard1_txtWorkPhone0").value, document.getElementById("UserWizard1_txtWorkPhone1").value)) {
       // alert("Please enter Work Phone ex. (000)000-0000");
        insertErrorLeft("Please enter Work Phone ex. 000-000-0000");
        rval = false;
    }
    if (!validatePhoneNumber1(document.getElementById("UserWizard1_txtHomePhone").value, document.getElementById("UserWizard1_txtHomePhone0").value, document.getElementById("UserWizard1_txtHomePhone1").value)) {
       // alert("Please enter Home Phone ex. (000)000-0000");
        insertErrorLeft("Please enter Home Phone ex. 000-000-0000");
        rval = false;
    }
    if (validateRequired(document.getElementById("UserWizard1_txtEmail").value)) {
        if(!validateEmail(document.getElementById("UserWizard1_txtEmail").value)) {
          //  alert("Please enter Valid Email Adrress");
            insertErrorLeft("Please enter Valid Email Adrress");
            rval = false;
        }
    }
    if (!validateSoc1(document.getElementById("UserWizard1_txtSoc").value, document.getElementById("UserWizard1_txtSoc0").value, document.getElementById("UserWizard1_txtSoc1").value) ){
        //alert('Please enter valid Social Security Number (000-00-0000)');
        insertErrorLeft('Please enter valid Social Security Number (000-00-0000)');
        rval = false;
    }
    if (!validateDate(document.getElementById("UserWizard1_txtDOB").value)) {
       // alert('Please enter valid Date of Birth (mm/dd/yyyy)');
        insertErrorLeft('Please enter valid Date of Birth (mm/dd/yyyy)');
        rval = false;
    }
    if (document.getElementById("UserWizard1_cmbGender").value == "(Select)") {
        //alert("Please select your Gender");
        insertErrorRight("Please select your Gender");
        rval = false;
    }
    if (!validateRequired(document.getElementById("UserWizard1_txtHeight").value) && !validateRequired(document.getElementById("UserWizard1_txtHeightin").value)) {
        //alert("Please enter your Height (ex. 5\'8\")");
        insertErrorRight("Please enter your Height ");
        rval = false;
    }
    if (!validateRequired(document.getElementById("UserWizard1_txtWeight").value)) {
       // alert("Please enter Weight");
        insertErrorRight("Please enter Weight");
        rval = false;
    }
    
    if ( document.getElementById("UserWizard1_cmbChildren").value == "(Select)" ) {
       // alert("Please select the number of children.");
        insertErrorRight("Please select the number of children.");
        rval = false;
    }
    
    if ( document.getElementById("UserWizard1_cmbMaritalStatus").value == "(Select)" ) {
       // alert("Please select a marital status.");
        insertErrorRight("Please select marital status.");
        rval = false;
    }
    
    if ( document.getElementById("UserWizard1_cmbStatus").value == "(Select)" ) {
       // alert("Please select an employment status.");
        insertErrorRight("Please select employment status.");
        rval = false;
    }
    if (!validateDate(document.getElementById("UserWizard1_txtHireDate").value)) {
       // alert("Please select an employment status.");
        insertErrorRight("Please enter date of hire. (01/01/1980)");
        rval = false;
    }
    if (!validateRequired(document.getElementById("UserWizard1_txtHours").value)) {
        //alert("Please enter your Height (ex. 5\'8\")");
        insertErrorRight("Please enter Number of Hours per Week you work");
        rval = false;
    }
    
    //else
       // rval = true;

    if (!rval) {
        document.getElementById("Validation").style.display = "block";
    }
    return rval;
}

function insertErrorLeft(ErrorMessage) {
    var errorList = document.getElementById("ErrorListLeft");
    var newError = document.createElement('li');
    newError.innerHTML = ErrorMessage;
    errorList.appendChild(newError)
}

function insertErrorRight(ErrorMessage) {
    var errorList = document.getElementById("ErrorListRight");
    var newError = document.createElement('li');
    newError.innerHTML = ErrorMessage;
    errorList.appendChild(newError);
}

function cmbWaiverChange() {
    if (document.getElementById("cmbCoverage").value == "yes") {
        alert("By waiving all coverage at this time you understand that you and any dependents will not be able to participate unless you experiance a life change event, at the next open enrollment or as a late enrollee if applicable.");
        document.getElementById("txtAddress").disabled = true;
        document.getElementById("txtCity").disabled = true;
        document.getElementById("txtState").disabled = true;
        document.getElementById("txtZip").disabled = true;
        document.getElementById("txtWorkPhone").disabled = true;
        document.getElementById("txtHomePhone").disabled = true;
        document.getElementById("txtEmail").disabled = true;
        document.getElementById("txtSoc").disabled = true;
        document.getElementById("cmbMedicare").disabled = true;
        document.getElementById("txtWorkPhone").disabled = true;
        document.getElementById("cmbGender").disabled = true;
        document.getElementById("txtHeight").disabled = true;
        document.getElementById("txtWeight").disabled = true;
        document.getElementById("cmbMaritalStatus").disabled = true;
        document.getElementById("cmbChildren").disabled = true;
        document.getElementById("txtPhysician").disabled = true;
        document.getElementById("txtTitle").disabled = true;
        document.getElementById("txtHireDate").disabled = true;
        document.getElementById("cmbStatus").disabled = true;
        document.getElementById("txtHours").disabled = true;
        document.getElementById("txtSalary").disabled = true;
        document.getElementById("cmbDisabled").disabled = true;
    }
    else {
        document.getElementById("txtAddress").disabled = false;
        document.getElementById("txtCity").disabled = false;
        document.getElementById("txtState").disabled = false;
        document.getElementById("txtZip").disabled = false;
        document.getElementById("txtWorkPhone").disabled = false;
        document.getElementById("txtHomePhone").disabled = false;
        document.getElementById("txtEmail").disabled = false;
        document.getElementById("txtSoc").disabled = false;
        document.getElementById("cmbMedicare").disabled = false;
        document.getElementById("txtWorkPhone").disabled = false;
        document.getElementById("cmbGender").disabled = false;
        document.getElementById("txtHeight").disabled = false;
        document.getElementById("txtWeight").disabled = false;
        document.getElementById("cmbMaritalStatus").disabled = false;
        document.getElementById("cmbChildren").disabled = false;
        document.getElementById("txtPhysician").disabled = false;
        document.getElementById("txtTitle").disabled = false;
        document.getElementById("txtHireDate").disabled = false;
        document.getElementById("cmbStatus").disabled = false;
        document.getElementById("txtHours").disabled = false;
        document.getElementById("txtSalary").disabled = false;
        document.getElementById("cmbDisabled").disabled = false;
    }
}