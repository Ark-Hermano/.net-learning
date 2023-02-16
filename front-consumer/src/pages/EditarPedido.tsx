import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';

type Pedido = {
  id: number;
  produtoId: string;
  userId: string;
  dataCriacao: string;
};

type FormValues = {
  produtoId: string;
  userId: string;
};

const EditarPedido = () => {
  const { id } = useParams<{ id: string }>();
  const [pedido, setPedido] = useState<Pedido | null>(null);
  const [produtos, setProdutos] = useState<string[]>([]);
  const [usuarios, setUsuarios] = useState<string[]>([]);

  useEffect(() => {
    const fetchPedido = async () => {
      const { data } = await axios.get<Pedido>(`/api/pedidos/${id}`);
      setPedido(data);
    };
    const fetchProdutos = async () => {
      const { data } = await axios.get<string[]>('/api/produtos');
      setProdutos(data);
    };
    const fetchUsuarios = async () => {
      const { data } = await axios.get<string[]>('/api/usuarios');
      setUsuarios(data);
    };
    fetchPedido();
    fetchProdutos();
    fetchUsuarios();
  }, [id]);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const form = event.target as HTMLFormElement;
    const data = new FormData(form);
    try {
      await axios.put(`http://localhost:7249/api/pedidos/${id}`, {
        produtoId: data.get('produtoId'),
        userId: data.get('userId')
      });
      // history.push('/');
    } catch (error) {
      console.error(error);
    }
  };

  if (!pedido) {
    return <div>Carregando...</div>;
  }

  return (
    <div>
      <h1>Editar Pedido</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Produto:
          <select name="produtoId" required defaultValue={pedido.produtoId}>
            {produtos.map((produto) => (
              <option key={produto} value={produto}>
                {produto}
              </option>
            ))}
          </select>
        </label>
        <br />
        <label>
          Usuário:
          <select name="userId" required defaultValue={pedido.userId}>
            {usuarios.map((usuario) => (
              <option key={usuario} value={usuario}>
                {usuario}
              </option>
            ))}
          </select>
        </label>
        <br />
        <button type="submit">Enviar</button>
      </form>
    </div>
  );
};

export default EditarPedido;
