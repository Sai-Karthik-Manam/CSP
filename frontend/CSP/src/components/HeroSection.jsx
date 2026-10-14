import { Link } from "react-router-dom";

function HeroSection() {
    return (
        <section className="hero-section">
            <div className="hero-content">
                <span className="hero-badge">Citizen Services</span>
                <h1>Government Services</h1>
                <p>
                    Access citizen services online, submit applications,
                    upload documents, and track your applications from
                    one convenient place.
                </p>
                <div className="hero-actions">
                    <Link to="/register" className="primary-button">Create Account</Link>
                    <Link to="/services" className="secondary-button">Explore Services</Link>
                </div>
            </div>
        </section>
    );
}

export default HeroSection;