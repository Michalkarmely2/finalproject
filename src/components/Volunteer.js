import { useState } from "react";
import { useNavigate } from "react-router-dom"
import '../App.css';




export function Home() {
  return (
    <div >
      <h1 className="text-3xl font-bold mb-4">Welcome to HelpConnect!</h1>
      <p className="mb-6">A platform for volunteers and elderly people who need help.</p>
      <div className="space-x-4">
        <a href="/signup" className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">Sign Up</a>
        <a href="/login" className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">Log In</a>
      </div>
    </div>
  );
}

export function SignUp({ setUser }) {
  const navigate = useNavigate();
  const [form, setForm] = useState({ name: '', email: '', password: '', role: 'elderly' });

  const handleSubmit = (e) => {
    e.preventDefault();
    setUser(form);
    navigate('/dashboard');
  };

  return (
    <div className="max-w-md mx-auto mt-10 bg-white p-6 rounded shadow">
      <h2 className="text-xl font-semibold mb-4">Sign Up</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <input type="text" placeholder="Name" required className="w-full p-2 border rounded" onChange={(e) => setForm({ ...form, name: e.target.value })} />
        <input type="email" placeholder="Email" required className="w-full p-2 border rounded" onChange={(e) => setForm({ ...form, email: e.target.value })} />
        <input type="password" placeholder="Password" required className="w-full p-2 border rounded" onChange={(e) => setForm({ ...form, password: e.target.value })} />
        <select className="w-full p-2 border rounded" onChange={(e) => setForm({ ...form, role: e.target.value })}>
          <option value="elderly">Elderly</option>
          <option value="volunteer">Volunteer</option>
        </select>
        <button className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600">Create Account</button>
      </form>
    </div>
  );
}

export function Login({ setUser }) {
  const navigate = useNavigate();
  const [email, setEmail] = useState('');

  const handleLogin = () => {
    // Dummy user object for testing
    const dummyUser = {
      name: 'Test User',
      role: email.includes('vol') ? 'volunteer' : 'elderly'
    };
    setUser(dummyUser);
    navigate('/dashboard');
  };

  return (
    <div className="max-w-md mx-auto mt-10 bg-white p-6 rounded shadow">
      <h2 className="text-xl font-semibold mb-4">Log In</h2>
      <input type="email" placeholder="Email" className="w-full p-2 border rounded mb-4" onChange={(e) => setEmail(e.target.value)} />
      <button onClick={handleLogin} className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 w-full">Log In</button>
    </div>
  );
}

export function Dashboard({ user }) {
  return (
    <div className="max-w-2xl mx-auto mt-10 bg-white p-6 rounded shadow">
      <h2 className="text-2xl font-semibold mb-4">Hello, {user.name}!</h2>
      {user.role === 'volunteer' ? <VolunteerDashboard /> : <ElderlyDashboard />}
    </div>
  );
}

export function VolunteerDashboard() {
  return (
    <div>
      <h3 className="text-xl font-bold mb-2">Volunteer Dashboard</h3>
      <p className="text-gray-700">You can see help requests here (connects to backend).</p>
    </div>
  );
}

export function ElderlyDashboard() {
  return (
    <div>
      <h3 className="text-xl font-bold mb-2">Elderly Dashboard</h3>
      <p className="text-gray-700">You can request help here (connects to backend).</p>
    </div>
  );
}

