import { useState, useEffect } from "react";
import { Col } from "react-bootstrap";
import Dropdown from "react-bootstrap/Dropdown";
export default function Vendedores() {
  const [vendedores, setVendedores] = useState([]);

  const leerVendedores = async () => {
    try {
      const response = await fetch("https://localhost:7218/api/vendedor/vendedores");
      const data = await response.json();
      setVendedores(data);
    } catch (error) {
      console.log("error en cargar los vendedores");
    }
  };

  useEffect(() => {
    leerVendedores();
  }, []);

  return (
    <div className="container d-flex justify-content-center align-center">
      <div class="card text-dark bg-light mb-3">
     
        <div class="card-body">
          <Dropdown className="text-center">
            <h1 className="text-">Vendedores</h1>
            <Dropdown.Toggle variant="success" id="dropdown-basic">
              Dropdown Button
            </Dropdown.Toggle>
            <Dropdown.Menu>
              {vendedores.map((vendedores, index) => (
                <Dropdown.Item>
                  <li key={index}>{vendedores.descripcion}</li>
                </Dropdown.Item>
              ))}
            </Dropdown.Menu>
          </Dropdown>
        </div>
      </div>
    </div>
  );
}
