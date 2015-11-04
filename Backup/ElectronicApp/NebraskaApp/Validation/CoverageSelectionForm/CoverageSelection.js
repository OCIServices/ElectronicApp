var waiveMed = false;
var waiveDen = false;
var waiveVis = false;
var waiveDis = false;
var waiveLif = false;

function MedicalChanged(MedicalValue) {
    if (document.getElementById("UserWizard1_isSingle").value == "true") {
        if (document.getElementById("UserWizard1_isChildren").value == "false") {
            if (MedicalValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Please Select a Coverage Type";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Waive") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for yourself";
                waiveMed = true;
            }
        }
        else if (document.getElementById("UserWizard1_isChildren").value == "true") {
            if (MedicalValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Please Select a Coverage Type";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for Child(ren)";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee/Child(ren)") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Waive") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for Yourself and Child(ren)";
                waiveMed = true;
            }
        }
    }

    if (document.getElementById("UserWizard1_isSingle").value == "false") {
        if (document.getElementById("UserWizard1_isChildren").value == "false") {
            if (MedicalValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Please Select a Coverage Type";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for your Spouse";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee/Spouse") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Waive") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for Yourself and Spouse";
                waiveMed = true;
            }
        }
        else if (document.getElementById("UserWizard1_isChildren").value == "true") {
            if (MedicalValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Please Select a Coverage Type";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for your Spouse and Child(ren)";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee/Child(ren)") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for your Spouse";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee/Spouse") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for your Child(ren)";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Employee/Spouse/Child(ren)") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "";
                waiveMed = false;
            }
            else if (MedicalValue.value == "Waive") {
                document.getElementById("UserWizard1_tdMedicalWaiver").innerHTML = "Waiving Medical Coverage for Yourself, Spouse and Child(ren)";
                waiveMed = true;
            }
        }
    }
    
    checkWaiveAll();
}

function checkWaiveAll() {
    if ( waiveDen && waiveDis && waiveLif && waiveMed && waiveVis ){
        alert("By waiving all coverage at this time you understand that you and any dependents will not be able to participate unless you experiance a life change event, at the next open enrollment or as a late enrollee if applicable.");
    }
}

function DentalChanged(DentalValue) {
    if (document.getElementById("UserWizard1_isSingle").value == "true") {
        if (document.getElementById("UserWizard1_isChildren").value == "false") {
            if (DentalValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Please Select a Coverage Type";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "";
                waiveDen = false;
            }
            else if (DentalValue.value == "Waive") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for yourself";
                waiveDen = true;
            }
        }
        else if (document.getElementById("UserWizard1_isChildren").value == "true") {
            if (DentalValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Please Select a Coverage Type";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for Child(ren)";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee/Child(ren)") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "";
                waiveDen = false;
            }
            else if (DentalValue.value == "Waive") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for Yourself and Child(ren)";
                waiveDen = true;
            }
        }
    }

    if (document.getElementById("UserWizard1_isSingle").value == "false") {
        if (document.getElementById("UserWizard1_isChildren").value == "false") {
            if (DentalValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Please Select a Coverage Type";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for your Spouse";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee/Spouse") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "";
                waiveDen = false;
            }
            else if (DentalValue.value == "Waive") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for Yourself and Spouse";
                waiveDen = true;
            }
        }
        else if (document.getElementById("UserWizard1_isChildren").value == "true") {
            if (DentalValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Please Select a Coverage Type";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for your Spouse and Child(ren)";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee/Child(ren)") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for your Spouse";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee/Spouse") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for your Child(ren)";
                waiveDen = false;
            }
            else if (DentalValue.value == "Employee/Spouse/Child(ren)") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "";
                waiveDen = false;
            }
            else if (DentalValue.value == "Waive") {
                document.getElementById("UserWizard1_tdDentalWaiver").innerHTML = "Waiving Dental Coverage for Yourself, Spouse and Child(ren)";
                waiveDen = true;
            }
        }
    }
}

function VisionChanged(VisionValue) {
    if (document.getElementById("UserWizard1_isSingle").value == "true") {
        if (document.getElementById("UserWizard1_isChildren").value == "false") {
            if (VisionValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Please Select a Coverage Type";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "";
                waiveVis = false;
            }
            else if (VisionValue.value == "Waive") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for yourself";
                waiveVis = true;
            }
        }
        else if (document.getElementById("UserWizard1_isChildren").value == "true") {
            if (VisionValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Please Select a Coverage Type";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for Child(ren)";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee/Child(ren)") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "";
                waiveVis = false;
            }
            else if (VisionValue.value == "Waive") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for Yourself and Child(ren)";
                waiveVis = true;
            }
        }
    }

    if (document.getElementById("UserWizard1_isSingle").value == "false") {
        if (document.getElementById("UserWizard1_isChildren").value == "false") {
            if (VisionValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Please Select a Coverage Type";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for your Spouse";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee/Spouse") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "";
                waiveVis = false;
            }
            else if (VisionValue.value == "Waive") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for Yourself and Spouse";
                waiveVis = true;
            }
        }
        else if (document.getElementById("UserWizard1_isChildren").value == "true") {
            if (VisionValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Please Select a Coverage Type";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for your Spouse and Child(ren)";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee/Child(ren)") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for your Spouse";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee/Spouse") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for your Child(ren)";
                waiveVis = false;
            }
            else if (VisionValue.value == "Employee/Spouse/Child(ren)") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "";
                waiveVis = false;
            }
            else if (VisionValue.value == "Waive") {
                document.getElementById("UserWizard1_tdVisionWaiver").innerHTML = "Waiving Vision Coverage for Yourself, Spouse and Child(ren)";
                waiveVis = true;
            }
        }
    }
    
    checkWaiveAll();
}

function DisabilityChanged(DisabilityValue) {
    if (DisabilityValue.value == "Waive") {
        document.getElementById("UserWizard1_tdDisabilityWaiver").innerHTML = "Waiving Disability for Yourself";
        waiveDis = true;
    }
    else if (DisabilityValue.value == "(Select)") {
        document.getElementById("UserWizard1_tdDisabilityWaiver").innerHTML = "Please Select a Coverage Type";
        waiveDis = false;
    }
    else {
        document.getElementById("UserWizard1_tdDisabilityWaiver").innerHTML = "";
        waiveDis = false;
    }
    
    checkWaiveAll();
}

function LifeChanged(LifeValue) {
        if (document.getElementById("UserWizard1_isSingle").value == "true") {
        if (document.getElementById("UserWizard1_isChildren").value == "false") {
            if (LifeValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Please Select a Coverage Type";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "";
                waiveLif = false;
            }
            else if (LifeValue.value == "Waive") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for yourself";
                waiveLif = true;
            }
        }
        else if (document.getElementById("UserWizard1_isChildren").value == "true") {
            if (LifeValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Please Select a Coverage Type";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for Child(ren)";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee/Child(ren)") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "";
                waiveLif = false;
            }
            else if (LifeValue.value == "Waive") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for Yourself and Child(ren)";
                waiveLif = true;
            }
        }
    }

    if (document.getElementById("UserWizard1_isSingle").value == "false") {
        if (document.getElementById("UserWizard1_isChildren").value == "false") {
            if (LifeValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Please Select a Coverage Type";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for your Spouse";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee/Spouse") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "";
                waiveLif = false;
            }
            else if (LifeValue.value == "Waive") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for Yourself and Spouse";
                waiveLif = true;
            }
        }
        else if (document.getElementById("UserWizard1_isChildren").value == "true") {
            if (LifeValue.value == "(Select)") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Please Select a Coverage Type";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for your Spouse and Child(ren)";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee/Child(ren)") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for your Spouse";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee/Spouse") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for your Child(ren)";
                waiveLif = false;
            }
            else if (LifeValue.value == "Employee/Spouse/Child(ren)") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "";
                waiveLif = false;
            }
            else if (LifeValue.value == "Waive") {
                document.getElementById("UserWizard1_tdLifeWaiver").innerHTML = "Waiving Life Coverage for Yourself, Spouse and Child(ren)";
                waiveLif = true;
            }
        }
    }
    
    checkWaiveAll();
}
