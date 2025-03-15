window.reloadPage = () => {
    location.reload();
};

window.downloadImage = (imageData) => {
    const link = document.createElement("a");
    link.href = imageData;
    link.download = "KTP.png";
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};