const Card = ({Department:{name,manger}}) => {
    return (
        <div className="card m-2 " style={{width:'30%'}} >
            <div class="card-body">
                <h5 class="card-title">{name}</h5>
                <p>{manger}</p>
            </div>
        </div>
    );
}
export default Card;