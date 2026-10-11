import { useState } from "react";
import PublicLayout from "../layouts/PublicLayout";
import {Registration} from "../services/authServices";
import { useNavigate } from "react-router-dom";

function Register() {

    const navigate=useNavigate();
    const [isSubmitting,setIsSubmitting]=useState(false);
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [mobileNumber, setMobileNumber] = useState("");
    const [dob, setDob] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [photo, setPhoto] = useState(null);
    const [errors,setErrors]=useState("");
    const handlePhotoChange = (event) => {
        const selectedPhoto = event.target.files[0];
        setPhoto(selectedPhoto);
    };
    const handleSubmit =async (event)=>{
        event.preventDefault();
        const validateError={};
        if(name.trim()===""){
            validateError.name="Name is Required";
        }
        if(email.trim()===""){
            validateError.email="Email is Required";
        }
        if(mobileNumber.length<=0){
            validateError.mobileNumber="Mobile Number is Required";
        }
        if(!dob){
            validateError.dob="Date of Birth is Required";
        }
        if(!password){
            validateError.password="Password is Required";
        }
        if(password && confirmPassword && password!==confirmPassword){
            validateError.confirmPassword="Cofirm Password does not Matched";
        }
        if(!photo){
            validateError.photo="Profile Photo is Required";
        }
        setErrors(validateError);
        if(Object.keys(validateError).length>0)
            return;
        const formData=new FormData();
        formData.append("Name",name);
        formData.append("Email",email);
        formData.append("MobileNumber",mobileNumber);
        formData.append("DOB",dob);
        formData.append("Password",password);
        formData.append("Image",photo);
        try {

            setIsSubmitting(true);
            const result = await Registration(formData);

            if(result.flag==0){
                alert(`${result.message}`);
            }
            else{
                alert(`${result.message}\n Citizen ID: ${result.citizenID}`)
                navigate("/Login");
            }
        } catch (error) {
            alert("Registraion Failed");
            console.error(error);

        }
        finally{
            setIsSubmitting(false);
        }
    };
    return (
        <PublicLayout>
            <section className="page">
                <div className="container">
                    <div className="header">
                        <span>CREATE ACCOUNT</span>
                        <h1>Join Citizen Service Portal</h1>
                        <p>
                            Create your citizen account to access
                            government services online.
                        </p>
                    </div>
                    <form onSubmit={handleSubmit}>
                        {/* Name */}

                        <div className="form-group">
                            <label htmlFor="name">Full Name</label>

                            <input id="name" type="text" value={name} onChange={(event) =>
                                setName(event.target.value)} placeholder="Enter your full name"
                            />
                            {errors.name && (
                                <p className="field-error">
                                    {errors.name}
                                </p>
                            )}
                        </div>


                        {/* Email */}
                        <div className="form-group">
                            <label htmlFor="email">Email Address</label>
                            <input
                                id="email"
                                type="email"
                                value={email}
                                onChange={(event) =>
                                    setEmail(event.target.value)
                                }
                                placeholder="Enter your email"
                            />
                            {errors.email && (
                                <p className="field-error">
                                    {errors.email}
                                </p>
                            )}
                        </div>


                        {/* Mobile */}
                        <div className="form-group">
                            <label htmlFor="mobileNumber">Mobile Number</label>
                            <input
                                id="mobileNumber"
                                type="tel"
                                value={mobileNumber}
                                onChange={(event) =>
                                    setMobileNumber(event.target.value)
                                }
                                placeholder="Enter your mobile number"
                            />
                            {errors.mobileNumber && (
                                <p className="field-error">
                                    {errors.mobileNumber}
                                </p>
                            )}

                        </div>


                        {/* DOB */}
                        <div className="form-group">
                            <label htmlFor="dob">Date of Birth</label>
                            <input
                                id="dob"
                                type="date"
                                value={dob}
                                onChange={(event) =>
                                    setDob(event.target.value)
                                }
                            />
                            {errors.dob && (
                                <p className="field-error">
                                    {errors.dob}
                                </p>
                            )}

                        </div>


                        {/* Password */}
                        <div className="form-group">
                            <label htmlFor="password">Password</label>
                            <input
                                id="password"
                                type="password"
                                value={password}
                                onChange={(event) =>
                                    setPassword(event.target.value)
                                }
                                placeholder="Create a password"
                            />
                            {errors.password && (
                                <p className="field-error">
                                    {errors.password}
                                </p>
                            )}

                        </div>


                        {/* Confirm Password */}
                        <div className="form-group">
                            <label htmlFor="confirmPassword">Confirm Password</label>
                            <input
                                id="confirmPassword"
                                type="password"
                                value={confirmPassword}
                                onChange={(event) =>
                                    setConfirmPassword(event.target.value)
                                }
                                placeholder="Confirm your password"
                            />
                            {errors.confirmPassword && (
                                <p className="field-error">
                                    {errors.confirmPassword}
                                </p>
                            )}

                        </div>


                        {/* Photo */}

                        <div className="form-group">
                            <label htmlFor="photo">Profile Photo</label>
                            <input
                                id="photo"
                                type="file"
                                accept="image/*"
                                onChange={handlePhotoChange}
                            />
                            {errors.photo && (
                                <p className="field-error">
                                    {errors.photo}
                                </p>
                            )}

                        </div>
                        <button type="submit" disabled={isSubmitting} className="button" >{isSubmitting?"Creating Account":"Create Account"}</button>
                    </form>
                </div>
            </section>
        </PublicLayout>
    );
}

export default Register;