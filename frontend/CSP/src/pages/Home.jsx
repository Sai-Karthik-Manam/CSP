import PublicLayout from "../layouts/PublicLayout";
import HeroSection from "../components/HeroSection";
import PopularServices from "../components/PopularServices";

function Home() {
    return (
        <PublicLayout>

            <HeroSection />

            <PopularServices />

        </PublicLayout>
    );
}

export default Home;