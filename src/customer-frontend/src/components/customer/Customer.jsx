import React, {Component} from "react";
import axios from "axios";

import Main from "../template/Main";

const headerProps = {
    icon: 'users',
    title: 'Clientes'
}
const baseUrl = 'https://localhost:7153';
const initialState = {
    customer: {
        name: '',
        email: '',
        birthday: '',
        address: {
            cep: '',
            logradouro: '',
            complemento: '',
            bairro: '',
            localidade: '',
            uf: ''
        }
    },
    list:[
        {
            id: 1,
            name: 'José da Silva',
            email: 'josesilva@hotmail.com',
            birthday: '25/12/1970',
            address: {
                cep: '60140170',
                logradouro: 'Rua de Cima',
                complemento: '200',
                bairro: 'Centro',
                localidade: 'São Paulo',
                uf: 'SP'
            }
        }
    ]
}


export default class Customer extends Component {
    state={...initialState}
    
    componentWillMount() {
        axios(`${baseUrl}/GetCustomers`).then(resp => {
            this.setState({list: resp.data})
        })
    }

    clear() {
        this.setState({customer: initialState.customer})
    }

    save() {
        const customer = this.state.customer
        const method = customer.id ? 'put' : 'post'
        const url = customer.id ? `${baseUrl}/${customer.id}` : baseUrl
        axios[method](url, customer).then(resp => {
            const list = this.getUpdatedList(resp.data)
            this.setState({customer: initialState.customer, list})
        })
    }

    searchAddress(event) {
        const cep = event.target.value
        axios.get(`${baseUrl}/GetAddress/${cep}`).then(resp => {
            this.setState({customer: resp.data})
        })
    }

    getUpdatedList(customer) {
        const list = this.state.list.filter(c => c.id !== customer.id)
        list.unshift(customer)
        return list
    }

    updateFields(event) {
        const customer = {...this.state.customer}
        customer[event.target.name] = event.target.value
        this.setState({customer})
    }

    renderForm() {
        return (
            <div className="form">
                <div className="row">
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>Nome</label>
                            <input type="text" className="form-control"
                                name="name"
                                value={this.state.customer.name}
                                onChange={e => this.updateFields(e)}
                                placeholder="Digite o nome..." />
                        </div>
                    </div>
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>Email</label>
                            <input type="email" className="form-control"
                                name="email"
                                value={this.state.customer.email}
                                onChange={e => this.updateFields(e)} />
                        </div>
                    </div>
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>Data de aniversário</label>
                            <input type="date" className="form-control"
                                name="birthday"
                                value={this.state.customer.birthday}
                                onChange={e => this.updateFields(e)} />
                        </div>
                    </div>
                </div>
                <hr />
                <div className="row">
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>CEP</label>
                            <input type="number" className="form-control"
                                name="cep"
                                value={this.state.customer.address.cep}
                                onChange={e => this.updateFields(e)} />
                        </div>
                    </div>
                    <div className="col-md-4">
                        <div className="form-group">
                            <button className="btn btn-secondary ml-2"
                                onClick={e => this.searchAddress(e)}>
                                    Pesquisar CEP
                            </button>  
                        </div>
                    </div>
                <div />
                <div className="row">
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>Logradouro</label>
                            <input type="text" className="form-control"
                                name="logradouro"
                                value={this.state.customer.address.logradouro}
                                onChange={e => this.updateFields(e)} />
                        </div>
                    </div>
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>Complemento</label>
                            <input type="text" className="form-control"
                                name="complemento"
                                value={this.state.customer.address.complemento}
                                onChange={e => this.updateFields(e)} />
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>Bairro</label>
                            <input type="text" className="form-control"
                                name="bairro"
                                value={this.state.customer.address.bairro}
                                onChange={e => this.updateFields(e)} />
                        </div>
                    </div>
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>Localidade</label>
                            <input type="text" className="form-control"
                                name="localidade"
                                value={this.state.customer.address.localidade}
                                onChange={e => this.updateFields(e)} />
                        </div>
                    </div>
                    <div className="col-md-4">
                        <div className="form-group">
                            <label>UF</label>
                            <input type="text" className="form-control"
                                name="uf"
                                value={this.state.customer.address.uf}
                                onChange={e => this.updateFields(e)} />
                        </div>
                    </div>
                </div>
                <br/>
                <hr/>
                <div className="row">
                    <div className="col-md-2">
                        <button className="btn btn-primary"
                            onClick={e => this.save(e)}>
                            Salvar
                        </button>
                    </div>
                    <div className="col-md-2">
                        <button className="btn btn-secondary ml-2"
                            onClick={e => this.clear(e)}>
                            Cancelar
                        </button>
                    </div>
                </div>
            </div>
        </div>
        )
    }

    load(customer) {
        this.setState({customer})
    }

    remove(id) {
        axios.delete(`${baseUrl}/DeleteCustomer/${id}`).then(resp => {
            const list = this.getUpdatedList(resp.data)
            this.setState(list)
        })
    }

    renderTable() {
        return (
            <table className="table mt-4">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Email</th>
                        <th>Aniversário</th>
                        <th>CEP</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {this.renderRows()}
                </tbody>
            </table>
        )
    }

    renderRows() {
        return this.state.list.map(customer => {
            return (
                <tr key={customer.id}>
                    <td>{customer.name}</td>
                    <td>{customer.email}</td>
                    <td>{customer.birthday}</td>
                    <td>{customer.address.cep}</td>
                    <td>
                        <button className="btn btn-warning"
                            onClick={() => this.load(customer)}>
                            <i className="fa fa-pencil"></i>
                        </button>
                        <button className="btn btn-danger"
                            onClick={() => this.remove(customer)}>
                            <i className="fa fa-trash"></i>
                        </button>
                    </td>
                </tr>
            )
        })
    }

    render() {
        return (
            <Main {...headerProps}>
                {this.renderForm()}
                <hr/>
                <div className="container">
                    <li>Listagem de Clientes</li>
                </div>
                <hr/>
                {this.renderTable()}
            </Main>
        )
    }
}