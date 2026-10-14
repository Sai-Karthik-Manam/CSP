import { useEffect, useState } from "react";
import ServiceCard from "./ServiceCard";
import { GetServices } from "../services/services";

function PopularServices() {
    const [services, setServices] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        const fetchServices = async () => {
            try {
                const data = await GetServices();
                setServices(data);
            } catch(error) {
                setError("Unable to load services.");
                console.log(error);
            } finally {
                setLoading(false);
            }
        };

        fetchServices();
    }, []);
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

                {loading && <p>Loading services...</p>}

                {error && <p className="field-error">{error}</p>}

                {!loading && !error && services.length === 0 && (
                    <p>No services available.</p>
                )}

                {!loading && !error && services.map((service) => (
                    <ServiceCard
                        key={service.id}
                        icon="📄"
                        title={service.serviceName}
                        description={`Access ${service.serviceName} services online.`}
                    />
                ))}
            </div>
        </section>
    );
}

export default PopularServices;