
import '../App.css';
import { Link } from 'react-router-dom';

export default function Home() {
  return (
    <div>
      <h1>Welcome to HelpConnect</h1>
      <p>This platform connects volunteers with elderly people who need help.</p>
      <div style={{ textAlign: 'center' }}>
        <Link to="/signup" className="button">Sign Up</Link>
        <Link to="/login" className="button">Log In</Link>
      </div>
    </div>
  );
}
