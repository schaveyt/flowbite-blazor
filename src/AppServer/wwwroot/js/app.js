
// Show a loading indication to the user during Blazor SSR enhanced navigation
//
// credit: Abhay Prince
//
// supports Blazor ASP.NET 8.0
//------------------------------------------------------------------------------------------------------------
const blazorGlobalLoaderId = 'blazor-global-loader';
const loaderDomElement = document.getElementById(blazorGlobalLoaderId);

if (loaderDomElement != null)
{
    // Show the modal if enhanced navigation is occurring....
    //
    const { fetch : originalFetch } = window;

    window.fetch = async (...args) => {

        // get options/configs of the fetch request
        //
        const [url, options] = args;

        // if the requester's headers include an 'accept' header
        // with 'blazor-enhanced-nav=on' in its text, display the
        // loader.
        //
        if (options !== undefined) {
            if (options.hasOwnProperty('headers') ) {
                if (options.headers !== undefined) {
                    const acceptHeader = options.headers['accept'];
                    if (acceptHeader !== undefined) {
                        if (acceptHeader.indexOf('blazor-enhanced-nav=on') !== -1) {
                            if (loaderDomElement !== undefined) {
                                // console.log("show blazor enhanced navigation spinner. " + Date.now());
                                // loaderDomElement.showModal();
                                loaderDomElement.classList.remove('hidden');
                            }
                        }
                    } 
                }
            }
        }

        // perform the original fetch
        //
        return await originalFetch(url, options);
    }
}




//
// Hide the modal if enhanced navigation has been loaded (i.e. completed)....
//
Blazor.addEventListener('enhancedload', function() {
    if (loaderDomElement != null) {
        // loaderDomElement.close();
        // console.log("hide blazor enhanced navigation spinner. " + Date.now());
        loaderDomElement.classList.add('hidden');
    }
});

//------------------------------------------------------------------------------------------------------------