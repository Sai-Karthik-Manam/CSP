import {Link} from 'react-router-dom';
import {useState} from 'react';
function Navbar(){
    const [menuOpen,setMenuOpen]=useState(false);
    const toggleMenu=()=>{
        setMenuOpen(!menuOpen);
    };
    const closeMenu=()=>{
        setMenuOpen(false);
    };
    return(
        <header className='navbar'>
            <div className="navbar-container">
                <Link to="/" className='navbar-logo' onClick={closeMenu}>
                <span className="logo-icon">🏛</span>
                <span>Citizen Service Portal</span>
                </Link>

                <nav className="desktop-nav">
                    <Link to="/">Home</Link>
                    <Link to="/services">Services</Link>
                    <Link to="/login">Login</Link>
                    <Link to="/register" className="nav-register">Register</Link>
                </nav>

                {/* Mobile Menu Button */}
                <button className="menu-button" onClick={toggleMenu} aria-label="Toggle navigation menu" >☰</button>
            </div>
            
             {/* Mobile Navigation */}
            {menuOpen && (
                <nav className="mobile-nav">
                    <Link to="/" onClick={closeMenu}>Home</Link>
                    <Link to="/services" onClick={closeMenu}>Services</Link>
                    <Link to="/login" onClick={closeMenu}>Login</Link>
                    <Link to="/register" onClick={closeMenu}>Register</Link>
                </nav>
            )}
        </header>
    );
}
export default Navbar;