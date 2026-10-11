import Navbar from "../components/Navbar";

function PublicLayout({ children }) {
    return (
        <>
            <Navbar />

            <main>
                {children}
            </main>

            <footer>
                <p>Citizen Service Portal © 2026</p>
            </footer>
        </>
    );
}

export default PublicLayout;