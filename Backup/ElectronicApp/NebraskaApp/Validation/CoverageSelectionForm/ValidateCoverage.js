function valSubmit() {

    if (document.getElementById("UserWizard1_isMedical").value == "true") {
        if (document.getElementById("UserWizard1_cmbMedical").value == "(Select)") {
            alert("Please Select a Medical Coverage Type")
            return false;
        }
    }
    if (document.getElementById("UserWizard1_isDental").value == "true") {
        if (document.getElementById("UserWizard1_cmbDental").value == "(Select)") {
            alert("Please Select a Dental Coverage Type")
            return false;
        }
    }
    if (document.getElementById("UserWizard1_isVision").value == "true") {
        if (document.getElementById("UserWizard1_cmbVision").value == "(Select)") {
            alert("Please Select a Vision Coverage Type")
            return false;
        }
    }
    if (document.getElementById("UserWizard1_isDisability").value == "true") {
        if (document.getElementById("UserWizard1_cmbDisability").value == "(Select)") {
            alert("Please Select a Disability Coverage Type")
            return false;
        }
    }
    if (document.getElementById("UserWizard1_isLife").value == "true") {
        if (document.getElementById("UserWizard1_cmbLife").value == "(Select)") {
            alert("Please Select a Life Coverage Type")
            return false;
        }
    }
}
  