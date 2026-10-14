import {useState} from 'react';
import PublicLayout from '../layouts/PublicLayout';
import { useNavigate } from "react-router-dom";
import {LoginUser} from "../services/authServices";
function Login(){

    const navigate=useNavigate();
    const [email,setEmail]=useState("");
    const [password,setPassword]=useState("");
    const [error,setError]=useState("");
    const [isSubmitting,setIsSubmitting]=useState(false);
    const handleSubmit=async(event)=>{
        event.preventDefault();
        const validationError={};
        console.log(password);
        if(email.trim()===""){
            validationError.email="Email is Required";
        }
        if(password.trim()===""){
            validationError.password="Password is Required";
        }
        setError(validationError);
        if(Object.keys(validationError).length>0)
            return;

        const data={

            Email:email,
            Password:password
        }
        try{
            setIsSubmitting(true);
            const result= await LoginUser(data);
            if(result.flag===1){
                alert(`${result.message}`);
                navigate("/Home");
            }
            else{
                alert(`${result.message}`);
            }
            
        }
        catch(error){
            console.log(error);
        }
        finally{
            setIsSubmitting(false);
        }
    }
    return(
        <>
            <PublicLayout>
                <section className="page">
                    <div className="container">
                        <div className="header">
                            <span><h1>Login</h1></span>
                        </div>
                        <form onSubmit={handleSubmit}>
                            <div className="form-group">
                                <label htmlFor="email">Email</label>
                                <input type="email" value={email} onChange={(event=>setEmail(event.target.value))}/>
                                {error.email && (
                                    <p className="field-error">
                                        {error.email}
                                    </p>
                                )}
                            </div>
                            <div className="form-group">
                                <label htmlFor="password">Password</label>
                                <input type="password" value={password} onChange={(event=>setPassword(event.target.value))}/>
                                {error.password && (
                                    <p className="field-error">
                                        {error.password}
                                    </p>
                                )}
                            </div>
                            <button type="submit" disabled={isSubmitting} className="button">{isSubmitting?"Please Wait":"Login"}</button>
                        </form>
                    </div>
                </section>
            </PublicLayout>
        </>
    );
}
export default Login;