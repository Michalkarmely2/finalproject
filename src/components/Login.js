import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../App.css';

export default function Auth() {
  const [isLogin, setIsLogin] = useState(true);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [role, setRole] = useState('volunteer');
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    if (isLogin) {
      alert(`Logged in as ${email}`);
    } else {
      alert(`Signed up as ${role} with email ${email}`);
    }
    navigate('/dashboard');
  };

  return (
    <div className="auth-wrapper">
      <div className="auth-box">
        <h1 className="auth-title">{isLogin ? 'Login' : 'Sign Up'}</h1>

        <form onSubmit={handleSubmit} className="auth-form">
          <label className="form-label">Email:</label>
          <input
            type="email"
            className="form-input"
            required
            value={email}
            onChange={e => setEmail(e.target.value)}
          />

          <label className="form-label">Password:</label>
          <input
            type="password"
            className="form-input"
            required
            value={password}
            onChange={e => setPassword(e.target.value)}
          />

          {!isLogin && (
            <>
              <label className="form-label">Select Role:</label>
              <select
                value={role}
                onChange={e => setRole(e.target.value)}
                className="form-input"
              >
                <option value="volunteer">Volunteer</option>
                <option value="elderly">Elderly Person</option>
              </select>
            </>
          )}

          <button type="submit" className="form-button">
            {isLogin ? 'Login' : 'Sign Up'}
          </button>
        </form>

        <p className="toggle-text">
          {isLogin ? "Don't have an account?" : 'Already have an account?'}
          <button className="toggle-button" onClick={() => setIsLogin(!isLogin)}>
            {isLogin ? 'Create Account' : 'Login'}
          </button>
        </p>
      </div>
    </div>
  );
}
