// src/EmailInput.jsx
import { useState } from 'react';
import axios from 'axios';

const EmailInput = () => {
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');

    const handleEmailChange = (e) => {
        setEmail(e.target.value);
    };

    const handleSubmit = async (e) => {
        e.preventDefault(); // Предотвращаем перезагрузку страницы

        try {
            const response = await axios.post('https://localhost:7277/api/Registration/register', { email });
            setMessage(response.data.message); // Предполагаем, что сервер возвращает сообщение
        } catch (error) {
            setMessage('Error sending verification code.'); // Обработка ошибок
            console.error(error);
        }
    };

    return (
        <div>
            <h1>Email Verification</h1>
            <form onSubmit={handleSubmit}>
                <input
                    type="email"
                    value={email}
                    onChange={handleEmailChange}
                    placeholder="Enter your email"
                    required
                />
                <button type="submit">Send Verification Code</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    );
};

export default EmailInput;