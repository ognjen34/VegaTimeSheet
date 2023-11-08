import React from 'react';
import './css/Footer.css';

const Footer = ({ color,text, onClick }) => {
  

  return (
<footer className="footer">
			<div className="wrapper">
				<ul>
					<li>
						<span>Copyright. VegaITSourcing All rights reserved</span>
					</li>
				</ul>
				<ul className="right">
					<li>
						<a >Terms of service</a>
					</li>
					<li>
						<a  className="last">Privacy policy</a>
					</li>
				</ul>
			</div>
		</footer>
  );
};

export default Footer;