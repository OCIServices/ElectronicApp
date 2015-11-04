function cmbMedicareChanged(myValue)
{
    if(myValue.value == "yes")
    {
        document.getElementById("Medicare").style.display = "block";
    }
    else
    {
        document.getElementById("Medicare").style.display = "none";
    }
}

function cmbConcurrentChanged(myValue)
{
    if(myValue.value == "yes")
    {
        document.getElementById("ConcurrentCoverage").style.display = "block";
    }
    else
    {
        document.getElementById("ConcurrentCoverage").style.display = "none";
    }
}

function cmbPreviousChanged(myValue)
{
    if(myValue.value == "yes")
    {
        document.getElementById("PreviousCoverage").style.display = "block";
    }
    else
    {
        document.getElementById("PreviousCoverage").style.display = "none";
    }
}

function valSubmit() {

    rval = true;
    if (document.getElementById("UserWizard1_DropDownList1").value == "(Select)") {
        alert("Please select whether or not you or any of your dependents are covered by medicare");
        rval = false;
        return rval;
    }
    if (document.getElementById("UserWizard1_cmbConcurrentCoverage").value == "(Select)") {
        alert("Please select whether or not you or any of your dependents have concurrent coverage");
        rval = false;
        return rval;
    }
    if (document.getElementById("UserWizard1_cmbPreviousCoverage").value == "(Select)") {
        alert("Please select whether or not you or any of your dependents have previous coverage");
        rval = false;
        return rval;
    }

   if (document.getElementById("UserWizard1_DropDownList1").value == "yes") {
        if (!validateRequired(document.getElementById("txtMedicareName").value)) {
            alert("Please enter name of person(s) covered by medicare");
            rval = false;
        }
        else if (!validateRequired(document.getElementById("UserWizard1_txtMedicareID").value)) {
            alert("Please enter ID# of person(s) covered by medicare");
            rval = false;
        }
        else if (!validateRequired(document.getElementById("UserWizard1_txtMedicareName").value)) {
            alert("Please enter name of person(s) covered by medicare");
            rval = false;
        }
        
    }
    if (document.getElementById("UserWizard1_cmbConcurrentCoverage").value == "yes") {
    
        if ( !document.getElementById("UserWizard1_ckMedical").checked &&
            !document.getElementById("UserWizard1_ckDental").checked &&
            !document.getElementById("UserWizard1_ckVision").checked &&
            !document.getElementById("UserWizard1_ckLife").checked &&
            !document.getElementById("UserWizard1_ckLife").checked ) {
                alert("Please select a type of coverage currently held.");
                rval = false;
                return rval;
        }
        
         if (!validateRequired(document.getElementById("UserWizard1_txtConcurentName").value)) {
            alert("Please enter the name of the concurrently covered individual.");
            rval = false;
            return rval;
        }
        
        if (!validateRequired(document.getElementById("UserWizard1_txtConcurrentProvider").value)) {
            alert("Please enter the name of the insurance provider for concurrent coverage.");
            rval = false;
            return rval;
        }
        
//        if (!validateRequired(document.getElementById("UserWizard1_txtConcurrentPolicy").value)) {
//            alert("Please enter the policy number for the concurrent policy.");
//            rval = false;
//            return rval;
//        }
        
        if (!validateRequired(document.getElementById("UserWizard1_txtConcurrentEff").value)) {
            alert("Please enter a valid effective date for the concurrent policy.");
            rval = false;
            return rval;
        }
        
        if (!validateRequired(document.getElementById("UserWizard1_txtConcurrentEnd").value)) {
            alert("Please enter a valid end date for the concurrent policy.");
            rval = false;
            return rval;
        }
        
        if (document.getElementById("UserWizard1_cmbConcurrentType").value=="(Select)") {
            alert("Please select a concurrent policy type.");
            rval = false;
            return rval;
        }
    }
    if (document.getElementById("UserWizard1_cmbPreviousCoverage").value == "yes") {
        
        if ( !validateRequired(document.getElementById("UserWizard1_txtPreviousName").value) ) {
            alert("Please enter the name(s) of the previously covered individuals.");
            rval = false;
            return rval;
        }
        
        if (!validateRequired(document.getElementById("UserWizard1_txtPreviousProvider").value)) {
            alert("Please enter the name of the insurance provider for previous coverage.");
            rval = false;
            return rval;
        }
        
//        if (!validateRequired(document.getElementById("UserWizard1_txtPolicy").value)) {
//            alert("Please enter the policy number for the previous policy.");
//            rval = false;
//            return rval;
//        }
        
        if (!validateRequired(document.getElementById("UserWizard1_txtPreviousEff").value)) {
            alert("Please enter an effective date for the previous policy.");
            rval = false;
            return rval;
        }
        
        if (!validateRequired(document.getElementById("UserWizard1_txtPreviousEnd").value)) {
            alert("Please enter an end date for the previous policy.");
            rval = false;
            return rval;
        }
        
        if (document.getElementById("UserWizard1_cmbPreviousType").value=="(Select)") {
            alert("Please select a Previous policy type.");
            rval = false;
            return rval;
        }
    }
    
    return rval;
}