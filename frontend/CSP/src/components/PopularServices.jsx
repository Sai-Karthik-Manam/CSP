import ServiceCard from "./ServiceCard";

function PopularServices() {
    return (
        <section className="popular-services">
            <div className="section-heading">
                <span>OUR SERVICES</span>
                <h2>Popular Citizen Services</h2>
                <p>
                    Access commonly used government services
                    quickly and conveniently.
                </p>
            </div>

            <div className="services-grid">

                <ServiceCard icon="📄" 
                title="Certificates"
                description="Apply for and manage important government certificates."
                />

                <ServiceCard
                    icon="🪪"
                    title="Identity Services"
                    description="Access identity-related citizen services and applications."
                />

                <ServiceCard
                    icon="📋"
                    title="Applications"
                    description="Submit applications and track their current status."
                />
            </div>
        </section>
    );
}

export default PopularServices;