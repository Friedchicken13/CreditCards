import {  useState,useEffect } from 'react';
import './App.css';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.css';

interface CreditCardDetails {
    type: string;
    cardNumber: string;
    isValid: boolean;
}

function App() {
    const [creditCardDetails,setCreditCardDetails] = useState<CreditCardDetails>();
    const [cardNumber, setCardNumber] = useState<string>();
    const [errorMessage, setErrorMessage] = useState<string>();

    useEffect(() => {
        if (cardNumber !== undefined)
                axios.get('CreditCard/CheckCard/' + cardNumber.replace(/ /g, ''))
                .then(res => {
                    setCreditCardDetails(res.data);
                }).catch(() => {
                    
                    setCreditCardDetails(undefined);
                    setErrorMessage("Credit card number cannot be an empty string");
                    
                })
    }, [cardNumber]);

    const contents = creditCardDetails === undefined ?
        errorMessage === undefined ? null : 
            <p>{ errorMessage}</p>:        
        <>
            <div className="row">
                <label className="form-label">Credit Card Type</label>
                <input className="form-control" type="text" value={creditCardDetails.type} disabled />
            </div>
            <div className="row">
                <label className="form-label">Credit Card Number</label>
                <input className="form-control" type="text" value={creditCardDetails.cardNumber} disabled />
            </div>
            <div className="row">
                <label className="form-label">Credit Card Status</label>
                <input className="form-control" type="text" value={creditCardDetails.isValid ? "Valid" : "Invalid"} disabled />
            </div>
        </>



    return (
        <div>
            <h1 >Credit Card Validator</h1>            
            <div className="row">
                <label className="form-label">Credit Card number</label>
                <input className="form-control" type="text" defaultValue={cardNumber} onChange={(e) => setCardNumber(e.target.value)} placeholder="Please write your credit card number" />
            </div>
            {contents}
        </div>
    );


}

export default App;