import { Carousel } from "react-bootstrap";
import { useState } from "react";

const Slider = () => {
    const [images, setImages] = useState([
        "https://images.wallpaperscraft.com/image/single/headphones_books_education_121501_1920x1080.jpg",
        "https://images.wallpaperscraft.com/image/single/vinyl_record_pink_needle_player_7250_1920x1080.jpg",
        "https://images.wallpaperscraft.com/image/single/electric_guitar_guitar_white_160582_1920x1080.jpg",
    ])
    return (
        <>
            <Carousel indicators={false} style={{height:'600px'}}>
                {
                    images.map(img => {
                        return (
                            <Carousel.Item style={{
                                backgroundImage:`url(${img})`,
                                backgroundPosition:'center',
                                backgroundSize:'cover',
                                height:'600px'
                                }}>
                            </Carousel.Item>
                        )
                    })
                }

            </Carousel>
        </>
    );
}

export default Slider;