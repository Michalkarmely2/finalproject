import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../App.css';


export default function SignUp() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [role, setRole] = useState('volunteer');
  const navigate = useNavigate();

  function handleSubmit(e) {
    e.preventDefault();
    alert(`Signed up as ${role} with email ${email}`);
    // כאן תרשימי לקרוא ל-API או משהו אחר
    navigate('/dashboard');
  }

  return (
    <div>
      <h1>Sign Up</h1>
      <form onSubmit={handleSubmit}>
        <label>Email:</label>
        <input type="email" required value={email} onChange={e => setEmail(e.target.value)} />

        <label>Password:</label>
        <input type="password" required value={password} onChange={e => setPassword(e.target.value)} />

        <label>Role:</label>
        <select value={role} onChange={e => setRole(e.target.value)}>
          <option value="volunteer">Volunteer</option>
          <option value="elderly">Elderly Person</option>
        </select>

        <button type="submit">Sign Up</button>
      </form>
    </div>
  );
}
