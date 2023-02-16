import { useState, useEffect } from 'react';
import axios from 'axios';

type Pedido = {
  id: number;
  produtoId: string;
  userId: string;
  dataCriacao: string;
};

type User = {
  id: number;
  produtoId: string;
  userId: string;
  dataCriacao: string;
};

type Product = {
  id: number;
  produtoId: string;
  userId: string;
  dataCriacao: string;
};

export const NovoPedido = () => {
  const [produtos, setProdutos] = useState<Product[]>([]);
  const [usuarios, setUsuarios] = useState<User[]>([]);

  useEffect(() => {
    const fetchProdutos = async () => {
      const { data } = await axios.get<Product[]>('http://localhost:7279/api/produtos');
      setProdutos(data);
    };
    const fetchUsuarios = async () => {
      const { data } = await axios.get<User[]>('http://localhost:7279/api/usuarios');
      setUsuarios(data);
    };
    fetchProdutos();
    fetchUsuarios();
  }, []);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const form = event.target as HTMLFormElement;
    const data = new FormData(form);
    try {
      await axios.post('http://localhost:7279/api/pedidos', {
        produtoId: data.get('produtoId'),
        userId: data.get('userId')
      });
      form.reset();
    } catch (error) {
      console.error(error);
    }
  };


  return (
    <div>
      <h1>Novo Pedido</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Produto:
          <select name="produtoId" required>
            <option value=""></option>
            {produtos.map((produto) => (
              <option key={produto.id} value={produto.id}>
                {produto.id}
              </option>
            ))}
          </select>
        </label>
        <br />
        <label>
          Usuário:
          <select name="userId" required>
            <option value=""></option>
            {usuarios.map((usuario) => (
              <option key={usuario.id} value={usuario.id}>
                {usuario.id}
              </option>
            ))}
          </select>
        </label>
        <br />
        <button type="submit">
          Salvar
        </button>
      </form>
    </div>
  );
};
